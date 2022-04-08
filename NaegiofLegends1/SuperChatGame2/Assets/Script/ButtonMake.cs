using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ButtonMake : MonoBehaviour
{
    public GameObject parent; //ボタンの親
    public KoubunManager koubunManager; //構文マネージャ
    public Text superChatText; //変えたいスーパーチャットのテキスト
    MakingSuperChat makingSuperChat;

    public List<GameObject> buttonsLists = new List<GameObject>(); //ここで作られたボタンのリスト

    void Start()
    {
        makingSuperChat = GameObject.Find("SuperChatButtonManager").GetComponent<MakingSuperChat>();
        parent = GameObject.Find("SuperChatText");
        superChatText = parent.gameObject.GetComponent<Text>();
        koubunManager = gameObject.GetComponent<KoubunManager>();
        GameObject originalButton = (GameObject)Resources.Load("Button");
        ButtonMaking(originalButton);
    }

    public void ButtonMaking(GameObject button)
    {
        for (int i = 0; i < KoubunManager.koubunChoiceList.Count; i++)
        {
            GameObject buttons = (GameObject)Instantiate(button, new Vector3(385, 120 - (i * 35), 0), Quaternion.identity);
            buttons.transform.SetParent(this.parent.transform, false);
            Button buttonsNaiyou = buttons.GetComponent<Button>();
            buttonsNaiyou.onClick.AddListener(() => { makingSuperChat.SuperChat(buttons); }); 
            Text text = buttons.transform.Find("Text").gameObject.GetComponent<Text>();
            text.text = KoubunManager.koubunChoiceList[i].name; //作ったボタンの名前を変えている
            buttonsLists.Add(buttons);
        }
    }

    public void DestroyButton()
    {
        while (buttonsLists.Count > 0)
        {
            Destroy(buttonsLists[0]);
            buttonsLists.RemoveAt(0);
        }
    }
}
