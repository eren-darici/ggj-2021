using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    void Update() 
    {
        Move();
    }

    void Move()
    {
        Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        playerInput = Vector3.ClampMagnitude(playerInput, 1f);
        transform.position += playerInput * movementSpeed * Time.deltaTime;
    }
}
