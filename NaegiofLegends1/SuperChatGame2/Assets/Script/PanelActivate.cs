using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelActivate : MonoBehaviour
{
    public GameObject panel;
    GameController gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    public void PanelSetting()
    {
        if (gameController.ojisanAction >= gameController.ojisanActionLimit)
        {
            return;
        }
        if (panel.activeSelf == false)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
