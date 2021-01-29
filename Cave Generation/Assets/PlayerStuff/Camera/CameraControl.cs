using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public MainCamera mainCamera;
    public Transform EntryRoom;
    
    void Start()
    {
        mainCamera.target = EntryRoom;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Room")
        {
            Debug.Log("hit");
            mainCamera.target = other.transform;
        }
    }
}
