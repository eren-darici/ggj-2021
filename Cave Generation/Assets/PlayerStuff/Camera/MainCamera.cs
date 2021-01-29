using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public float slideSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, target.position, slideSpeed) + new Vector3( 0 , 0 , -1f);

    }
}
