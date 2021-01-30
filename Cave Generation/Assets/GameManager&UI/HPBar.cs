using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Shoot playerScript;
    public GameObject player;
    public GameObject bar;
    public int playerHP;

    [Header("HP Sprites")]
    public Sprite hp1;
    public Sprite hp2;
    public Sprite hp3;
    public Sprite hp4;
    public Sprite hp5;
    public Sprite hp6;
    public Sprite hp7;
    public Sprite hp8;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Shoot>();
    }

    
    void Update()
    {
        playerHP = playerScript.hitpoints;
        CheckHP();
    }

    void CheckHP()
    {
        if (playerHP == 7)
        {
            bar.GetComponent<UnityEngine.UI.Image>().sprite = hp7;
        }
        else if (playerHP == 6)
        {
            bar.GetComponent<UnityEngine.UI.Image>().sprite = hp6;
        }
        else if (playerHP == 5)
        {
            bar.GetComponent<UnityEngine.UI.Image>().sprite = hp5;
        }
        else if (playerHP == 4)
        {
            bar.GetComponent<UnityEngine.UI.Image>().sprite = hp4;
        }
        else if (playerHP == 3)
        {
            bar.GetComponent<UnityEngine.UI.Image>().sprite = hp3;
        }
        else if (playerHP == 2)
        {
            bar.GetComponent<UnityEngine.UI.Image>().sprite = hp2;
        }
        else if (playerHP == 1)
        {
            bar.GetComponent<UnityEngine.UI.Image>().sprite = hp1;
        }
        else if (playerHP == 0)
        {
            Debug.Log("Game Over");
        }
    }
}
