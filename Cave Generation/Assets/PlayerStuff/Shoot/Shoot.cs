using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;


public class Shoot : MonoBehaviour
{
    [Range(0, 1.5f)]
    public float rateOfFire;
    private float timeCheck;
    PlayerMovement playerMovement;
    public GameObject projectile;
    Animator animator;
    public GameObject firepoint;
    public float projectileSpeed;
    Vector3 direction;
    public float dashSpeed;
    public bool isDash;
    Rigidbody2D rb;
    public int maxHP;
    TrailRenderer trailRenderer;

    public GameObject fireParticle;

    public AudioSource sourceGun;
    public AudioSource sourceHit;


    public int hitpoints;

    void Start()
    {
        animator = GetComponent<Animator>();

        timeCheck = 0;
        // playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        direction = new Vector3(-1, -1, 0);
        hitpoints = maxHP;
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        timeCheck = Mathf.Clamp(timeCheck - Time.deltaTime, 0, rateOfFire);
        ShootDirection();
        firepoint.transform.position = transform.position + direction / 2;
        firepoint.transform.rotation = Quaternion.Euler(0, 0, -90 + Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        Debug.Log(timeCheck);
        Fire();


    }
    private void FixedUpdate()
    {

        Dash();
        RenderTrail();
    }

    void Fire()
    {
        Vector2 input;
        input.x = Input.GetAxisRaw("HorizontalShoot");
        input.y = Input.GetAxisRaw("VerticalShoot");
        if (input.sqrMagnitude != 0 && timeCheck <= 0)
        {
            timeCheck = rateOfFire;
            Instantiate(fireParticle, firepoint.transform.position, Quaternion.identity);
            GameObject projectileInstance = Instantiate(projectile);
            projectileInstance.transform.position = firepoint.transform.position;
            float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
            projectileInstance.transform.rotation = Quaternion.Euler(0, 0, angle);
            projectileInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            sourceGun.Play();

        }

    }
    void ShootDirection()
    {
        Vector2 dir;
        dir.x = Input.GetAxisRaw("HorizontalShoot");
        dir.y = Input.GetAxisRaw("VerticalShoot");
        if (dir.x != 0 || dir.y != 0)
        {

            direction = dir.normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle = Mathf.Abs(angle);
            if (angle < 30f)
            {
                animator.SetTrigger("Right");
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (angle > 150)
            {
                animator.SetTrigger("Left");
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (angle > 30 && angle < 150)
            {
                if (dir.y <= 0)
                    animator.SetTrigger("Down");
                else animator.SetTrigger("Up");
            }
        }
        if (playerMovement.playerInput.sqrMagnitude == 0)
        {
            animator.SetTrigger("Idle");
        }

    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDash)
        {
            isDash = true;
            rb.velocity = playerMovement.playerInput * dashSpeed;
        }
        if (isDash)
        {
            rb.velocity -= rb.velocity.normalized * 1f;
        }
        if (rb.velocity.magnitude <= playerMovement.movementSpeed)
        {
            isDash = false;
        }
    }

    public void Damage()
    {
        sourceHit.Play();
        hitpoints--;
        if (hitpoints <= 0) Die();
    }

    void Die()
    {
        Debug.Log("DEAD");
        gameObject.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Heal()
    {
        hitpoints = Mathf.Clamp(++hitpoints, hitpoints, maxHP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Damage();
            Debug.DrawRay(transform.position, collision.transform.position - transform.position);
            rb.velocity = -(collision.transform.position - transform.position) * dashSpeed * 1.5f;
            isDash = true;
        }
    }

    void RenderTrail()
    {
        if (!isDash)
        {
            trailRenderer.Clear();
        }
    }

    void ChangeDirection()
    {

    }

}
