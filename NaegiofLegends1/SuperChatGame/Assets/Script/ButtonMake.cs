using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMake : MonoBehaviour
{
    public GameObject parent;

    void Start()
    {
        GameObject buttons = (GameObject)Resources.Load("Button");
        parent = GameObject.Find("Canvas");

        
    }


}
