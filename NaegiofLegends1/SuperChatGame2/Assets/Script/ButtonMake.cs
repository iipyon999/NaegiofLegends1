using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ButtonMake : MonoBehaviour
{
    public GameObject parent;
    public KoubunManager koubunManager;
    public Text superChatText;
    private KoubunLibrary koubunLibrary;

    public List<GameObject> buttonsLists = new List<GameObject>();

    void Start()
    {
        parent = GameObject.Find("Text");
        superChatText = parent.gameObject.GetComponent<Text>();
        koubunManager = gameObject.GetComponent<KoubunManager>();
        koubunLibrary = GetComponent<KoubunLibrary>();
        StartCoroutine("KoubunListCheck");
    }

    public void ButtonMaking(GameObject button)
    {
        for (int i = 0; i < koubunManager.choiseNum; i++)
        {
            GameObject buttons = (GameObject)Instantiate(button, new Vector3(385, 120 - (i * 35), 0), Quaternion.identity);
            buttons.transform.SetParent(this.parent.transform, false);
            Text text = buttons.transform.Find("Text").gameObject.GetComponent<Text>();
            text.text = koubunManager.koubunChoiceList[i].name; //作ったボタンの名前を変えている
            buttonsLists.Add(buttons);
        }
    }

    public void DestroyButton()
    {
        for(int i = 0; i < buttonsLists.Count; i++)
        {
            Destroy(buttonsLists[i]);
        }
    }

    IEnumerator KoubunListCheck()
    {
        while (koubunLibrary.koubunList.Count != koubunLibrary.rowLength || koubunLibrary.rowLength == 0)
        {
            yield return null;
            GameObject button = (GameObject)Resources.Load("Button");
            ButtonMaking(button);
        }
    }

}
