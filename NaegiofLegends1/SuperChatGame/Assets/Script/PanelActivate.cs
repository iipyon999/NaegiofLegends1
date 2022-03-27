using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelActivate : MonoBehaviour
{
    public GameObject panel;
    public void PanelActivating()
    {
        panel.SetActive(true);
    }
}
