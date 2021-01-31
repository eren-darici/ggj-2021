using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Image compass;
    public Transform boss;
    Vector3 bossVector;

    Animator animator;
    public float movementSpeed;
    public SpriteRenderer spriteRenderer;
    public int direction;
    public Vector3 playerInput;
    Vector3 moveDir;
    private Rigidbody2D rb;
    // 1 -> left
    // 2 -> right
    // 3 -> up
    // 4 -> down
    Shoot sc;

    private void Start()
    {
        animator = GetComponent<Animator>();
        sc = GetComponent<Shoot>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Move()
    {
         playerInput= new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

         ChangeDirection();
        
        playerInput = Vector3.ClampMagnitude(playerInput, 1f);
        moveDir = playerInput;

    }

    private void FixedUpdate()
    {

        Move();
        if (!sc.isDash)
        {
            rb.velocity = moveDir * movementSpeed;
        }
    }

    private void Update()
    {
        if (boss != null)
        {
            bossVector = (boss.position - transform.position).normalized;
            float angle = Mathf.Atan2(bossVector.y, bossVector.x) * Mathf.Rad2Deg;
            compass.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void ChangeDirection()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetTrigger("Right");
            direction = 2;  
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetTrigger("Left");
            direction = 1;
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            direction = 3;
            
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            direction = 4;
        }
    }




}
