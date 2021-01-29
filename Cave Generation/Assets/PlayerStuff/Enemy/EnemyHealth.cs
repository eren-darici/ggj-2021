using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
