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

    public Transform currentRoom;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPos = spawner.transform;

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
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (aiPath.desiredVelocity.y >= 0.1f)
        {
            // arkayı renderla
        }
        else if (aiPath.desiredVelocity.y <= 1.0f)
        {
            // önü renderla
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
