using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Wall" || other.tag == "Room")
       {
           Destroy(gameObject);
       }
   }
}
