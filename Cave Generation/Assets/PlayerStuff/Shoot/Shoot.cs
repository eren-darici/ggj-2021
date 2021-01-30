using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    PlayerMovement playerMovement;
    public GameObject projectile;
    public GameObject firepoint;
    public float projectileSpeed;
    Vector3 direction;

    void Start()
    {
       // playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        playerMovement =GetComponent<PlayerMovement>();
        direction = new Vector3(-1, -1,0);
    }

    void Update()
    {
        direction = ShootDirection();
        Fire();
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject projectileInstance = Instantiate(projectile);
            projectileInstance.transform.position = firepoint.transform.position;
            float angle = Mathf.Rad2Deg* Mathf.Atan2(direction.y, direction.x);
                Debug.Log("angle: " + angle);
            projectileInstance.transform.rotation = Quaternion.Euler(0,0,angle);
            projectileInstance.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            Debug.Log(projectileInstance.GetComponent<Rigidbody2D>().velocity);
        }
        
    }
    Vector3 ShootDirection()
    {
        if (playerMovement.playerInput.x != 0 || playerMovement.playerInput.y != 0)
        {   
            return playerMovement.playerInput.normalized;
        }
        else return direction;
    }
}
