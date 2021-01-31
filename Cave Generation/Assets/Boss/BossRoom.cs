using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    public int maxHp;
    public int hp;
    public Transform currentRoom;
    private MainCamera cam;
    Animator animator;
    bool isActive;
    bool isPrepared;
    public Transform firePoint;
    public Transform attack1;
    public Transform[] attack2;
    public GameObject projectile;
    public float projectileSpeed;
    Transform player;
    public int RageHealth;
    [HideInInspector]
    public bool isRaged;
    public BoxCollider2D roomcol;
    Color color;
    public GameObject bloodParticle;

    public GameObject gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
        color = GetComponent<SpriteRenderer>().color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        cam = Camera.main.GetComponent<MainCamera>();
        player.GetComponent<PlayerMovement>().boss = this.transform;
        hp = maxHp;
        Invoke("Prepare", 1f);
    }
    private void Update()
    {
        if(cam.target == currentRoom &&!isActive)
        {
            animator.SetTrigger("StartFight");
            isActive = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            foreach(Transform i in attack2)
            {
                Fire(i);
            }
        }

        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Wait State"))
        {
            Vector3 vect = (player.position - firePoint.position).normalized;
            firePoint.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(vect.y, vect.x)*Mathf.Rad2Deg);
        }
        if(hp<= RageHealth)
        {
            animator.SetTrigger("AttackTwo");
            isRaged = true;
        }
    }

    void Prepare()
    {
        foreach (GameObject x in items)
        {
            Destroy(x.gameObject);
        }
        isPrepared = true;
        roomcol.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isPrepared)
        {
            Debug.Log(collision.tag);
            items.Add(collision.gameObject);
        }
        }
    
    public void Fire(Transform pos)
    {

        GameObject instance=projectile;
       
        instance.transform.position = pos.position;
        
        instance =Instantiate(instance);
        instance.GetComponent<Rigidbody2D>().velocity = (pos.position - transform.position) * projectileSpeed;
    }

    public void Damage(int hit)
    {
        hp -= hit;
        if (hp <= 0) Die();
    }
    

    void Die()
    {
        Instantiate(bloodParticle, transform.position, Quaternion.identity);
        gm.GetComponent<Cutscene>().End();
        Destroy(gameObject);

    }

    public void ChangeState()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("BackToNormalColor", 0.3f);
    }
    void BackToNormalColor()
    {
        GetComponent<SpriteRenderer>().color = color;
    }

}
