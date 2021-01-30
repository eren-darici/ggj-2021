using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    List<GameObject> items = new List<GameObject>();
    void Start()
    {
        Invoke("Prepare", 1f);
    }

    void Prepare()
    {
        foreach (GameObject x in items)
        {
            Destroy(x.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        items.Add(collision.gameObject);
    }


}
