using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainMenu : MonoBehaviour
{
    public delegate void MenuUpdate();
    public MenuUpdate menuupdate;

    [SerializeField]
    public GameObject MainMenuObj;
    [SerializeField]
    public EquipMenu equipMenu;

    private void Start()
    {
        menuupdate = closing;
    }

    private void Update()
    {
        menuupdate();
    }

    public void closing()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenMenu();
            menuupdate = opening;
        }
    }

    public void opening()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CloseMenu();
            menuupdate = closing;
        }
    }

    public void OpenMenu()
    {
        MainMenuObj.SetActive(true);
    }

    public void CloseMenu()
    {
        MainMenuObj.SetActive(false);
    }
    public void EquipMenuOpen()
    {
        CloseMenu();
        equipMenu.OpenEquipMenu();
        menuupdate = equipMenu.EquipMenuMain;
    }
}
