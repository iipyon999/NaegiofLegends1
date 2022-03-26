using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMake : MonoBehaviour
{
    public GameObject button;
    public GameObject parent;

    void Start()
    {
        GameObject makingButton = Instantiate(button, new Vector3(385, 120, 0), Quaternion.identity);

    }
}
