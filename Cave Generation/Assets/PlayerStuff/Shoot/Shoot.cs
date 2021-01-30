using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class Shoot : MonoBehaviour
{
    PlayerMovement playerMovement;
    public GameObject projectile;
    public GameObject firepoint;
    public float projectileSpeed;
    Vector3 direction;
    public float dashSpeed;
    public bool isDash;
    Rigidbody2D rb;
    public int maxHP;

    public int hitpoints;

    void Start()
    {
        // playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        direction = new Vector3(-1, -1, 0);
        hitpoints = maxHP;
    }

    void Update()
    {
        direction = ShootDirection();
        Fire();
    }
    private void FixedUpdate()
    {

        Dash();
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject projectileInstance = Instantiate(projectile);
            projectileInstance.transform.position = firepoint.transform.position;
            float angle = Mathf.Rad2Deg* Mathf.Atan2(direction.y, direction.x);

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
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDash)
        {
            isDash = true;
            rb.velocity = direction * dashSpeed;
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

    void Damage()
    {
        hitpoints--;
        if (hitpoints <= 0) Die();
    }

    void Die()
    {
        Debug.Log("DEAD");
    }

    void Heal()
    {
        hitpoints = Mathf.Clamp(++hitpoints, hitpoints, maxHP);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Damage();
            Debug.DrawRay(transform.position, collision.transform.position - transform.position);
            rb.velocity = -(collision.transform.position - transform.position) * dashSpeed * 1.5f;
            isDash = true;
        }
    }
}
