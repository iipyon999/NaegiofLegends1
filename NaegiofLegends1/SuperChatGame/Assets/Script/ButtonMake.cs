using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMake : MonoBehaviour
{
    public GameObject parent;
    public KoubunManager koubunManager;

    void Start()
    {
        parent = GameObject.Find("Text");
        koubunManager = gameObject.GetComponent<KoubunManager>();
        StartCoroutine("ButtonChanging");
    }

    private void ButtonMaking()
    {

    }

    IEnumerator ButtonChanging()
    {
        if(koubunManager.koubunArrays == null)
        {
            yield return null;
        }

        GameObject button = (GameObject)Resources.Load("Button");
        for (int i = 0; i < 3; i++)
        {
            GameObject buttons = (GameObject)Instantiate(button, new Vector3(385, 120 - (i * 35), 0), Quaternion.identity);
            buttons.transform.SetParent(this.parent.transform, false);
            /*
            Text text = buttons.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            text.text = koubunManager.koubunArrays[i].name;
            */
        }


    }



}
