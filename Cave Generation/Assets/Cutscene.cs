using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    public GameObject blank;
    public GameObject one;
    public GameObject two;
    public GameObject three;

    public GameObject canv;
    public GameObject cutscenes;
    public GameObject levelOne;

    public GameObject endScreen;

    public int counter = 0;

    private void Update()
    {
        NextCut();
    }

    void NextCut()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            counter++;
            switch (counter)
            {
                case 0:
                    canv.SetActive(false);
                    break;
                case 1:
                    blank.SetActive(false);
                    one.SetActive(true);
                    two.SetActive(false);
                    three.SetActive(false);
                    break;
                case 2:
                    blank.SetActive(false);
                    one.SetActive(false);
                    two.SetActive(true);
                    three.SetActive(false);
                    break;
                case 3:
                    blank.SetActive(false);
                    one.SetActive(false);
                    two.SetActive(false);
                    three.SetActive(true);
                    break;
                case 4:
                    cutscenes.SetActive(false);
                    levelOne.SetActive(true);
                    canv.SetActive(true);
                    break;
            }
        }
    }

    public void End()
    {
        levelOne.SetActive(false);
        endScreen.SetActive(true);
    }
}
