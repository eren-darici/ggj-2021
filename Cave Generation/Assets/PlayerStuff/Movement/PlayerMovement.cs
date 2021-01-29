using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public SpriteRenderer spriteRenderer;
    public int direction;
    // 1 -> left
    // 2 -> right
    // 3 -> up
    // 4 -> down

    void Update() 
    {
        Move();
    }

    void Move()
    {
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        ChangeDirection();
        
        playerInput = Vector3.ClampMagnitude(playerInput, 1f);
        transform.position += playerInput * movementSpeed * Time.deltaTime;
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
