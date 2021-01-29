using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player" && other.tag != "Projectile" && other.tag != "Enemy")
        {
            Debug.Log(other.tag);
            Destroy(other.gameObject);
        }
    }
}
