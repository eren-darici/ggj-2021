using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() 
    {
       
        
        
      
    }

    void Move()
    {
         playerInput= new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        ChangeDirection();
        
        playerInput = Vector3.ClampMagnitude(playerInput, 1f);
        moveDir = playerInput;
        
    }

    private void FixedUpdate()
    {

        Move();
        
        
        rb.velocity = moveDir * movementSpeed;
    }
    void ChangeDirection()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
            direction = 2;
  
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
            direction = 1;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            direction = 3;
            
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            direction = 4;
        }
    }



}
