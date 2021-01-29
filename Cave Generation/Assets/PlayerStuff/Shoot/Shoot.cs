using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    PlayerMovement playerMovement;
    public GameObject projectile;
    public GameObject firepoint;
    public float projectileSpeed;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerMovement.direction == 2)
                
                Instantiate(projectile, firepoint.transform.position, Quaternion.Euler(0,0,0)).GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0f);
            
            if (playerMovement.direction == 1)
                
                Instantiate(projectile, firepoint.transform.position, Quaternion.Euler(0,180,0)).GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0f);
            
            if (playerMovement.direction == 3)
                
                Instantiate(projectile, firepoint.transform.position, Quaternion.Euler(0,0,90)).GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
            
            if (playerMovement.direction == 4)
                
                Instantiate(projectile, firepoint.transform.position, Quaternion.Euler(0,0,-90)).GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);

        }
    }
}
