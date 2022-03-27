using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonMake : MonoBehaviour
{
    public GameObject parent;
    public KoubunManager koubunManager;
    public Text superChatText;

    [SerializeField]
    string[] koubunTest = new string[3];

    void Start()
    {
        parent = GameObject.Find("Text");
        superChatText = parent.gameObject.GetComponent<Text>();
        koubunManager = gameObject.GetComponent<KoubunManager>();
        GameObject button = (GameObject)Resources.Load("Button");
        Button buttonNaiyou = button.gameObject.GetComponent<Button>();
        for (int i = 0; i < 3; i++)
        {
            GameObject buttons = (GameObject)Instantiate(button, new Vector3(385, 120 - (i * 35), 0), Quaternion.identity);
            buttons.transform.SetParent(this.parent.transform, false);
            TextMeshProUGUI text = buttons.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
            text.text = koubunManager.koubunArrays[i].name;
            buttonNaiyou.onClick.AddListener(KoubunMaking);
        }
    }

    private void KoubunMaking()
    {
        superChatText.text = koubunManager.koubunArrays[0].naiyou;
    }



}
