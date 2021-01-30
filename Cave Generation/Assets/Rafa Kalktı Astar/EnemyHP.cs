using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int hp;
    GameObject par;

    private void Start()
    {
        par = transform.parent.gameObject;
    }

    void Update()
    {
        if (hp <= 0)
        {
            transform.parent = null;
            Destroy(par);
            Destroy(this.gameObject);
        }
    }
}
