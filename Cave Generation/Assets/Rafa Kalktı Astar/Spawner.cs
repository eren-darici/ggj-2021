using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    GameObject item;
    public int numberOfEnemy = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Spawn();
    }

 
    void Spawn()
    {
        item = Instantiate(enemy, transform.position, Quaternion.identity, transform.parent);
        item.GetComponent<AIDestinationSetter>().target = player.transform;
        item.GetComponent<AIPath>().canSearch = true;
        item.GetComponentInChildren<EnemyGFX>().spawner = this.gameObject;
    }
}
