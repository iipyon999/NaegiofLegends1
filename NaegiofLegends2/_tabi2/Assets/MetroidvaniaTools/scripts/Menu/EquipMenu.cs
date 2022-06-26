using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMenu : MainMenu
{
    public GameObject obj;
    public void EquipMenuMain()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CloseEquipMenu();
            OpenMenu();
            menuupdate = opening;
        }
    }

    public void OpenEquipMenu()
    {
        obj.SetActive(true);
    }

    public void CloseEquipMenu()
    {
        obj.SetActive(false);
    }
}
