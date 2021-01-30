using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    Shoot player;
    public float moveSpeed;
    Rigidbody2D rb;
    public bool isDash;
    public float dashSpeed;
    Vector3 dir;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindObjectOfType<Shoot>();
    }


    private void FixedUpdate()
    {
        if (!isDash)
        {
            rb.velocity = dir * moveSpeed;
            
        }
        if (isDash)
        {
            Debug.Log("AAAA");
            rb.velocity -= rb.velocity.normalized * 1f;
        }
        if (rb.velocity.magnitude <= moveSpeed) isDash = false;
    }
}
