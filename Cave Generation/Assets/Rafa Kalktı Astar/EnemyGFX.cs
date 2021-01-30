using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public int threshhold;
    public GameObject player;
    public Transform startPos;
    public Camera cam;
    public GameObject spawner;

    public Animator animator;

    public Transform currentRoom;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPos = spawner.transform;

        animator = GetComponent<Animator>();

        cam = Camera.main;
        currentRoom = transform.parent.parent;
    }

    void Update()
    {
        flip();
        ControlAI();
        RoomCheck();
    }

    void ControlAI()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < threshhold)
        {
            aiPath.canMove = false;
        }
        else 
        {
            aiPath.canMove = true;
        }
    }


    void flip()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            animator.SetTrigger("Right");
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            animator.SetTrigger("Left");
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            animator.SetTrigger("Down");
        }
    }
    
    void RoomCheck()
    {
        Debug.Log(currentRoom.name);
        if (cam.GetComponent<MainCamera>().target != currentRoom)
        {
            GetComponentInParent<AIDestinationSetter>().target = startPos;
        }
        else
        {
            GetComponentInParent<AIDestinationSetter>().target = player.transform;
        }
    }
}
