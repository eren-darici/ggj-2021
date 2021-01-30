using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject doorTrigger;
    GameObject player;

    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
