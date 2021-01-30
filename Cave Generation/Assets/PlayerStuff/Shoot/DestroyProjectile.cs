using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    public int hitpoint = 10;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall" || other.tag == "Room")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHP>().hp -= hitpoint;
            Destroy(gameObject);
        }
    }
}
