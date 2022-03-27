using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MakingSuperChat : MonoBehaviour
{
    GameObject koubunM;
    KoubunManager koubunManager;
    GameObject text;
    Text superChatText;

    private void Start()
    {
        koubunM = GameObject.Find("KoubunManager");
        koubunManager = koubunM.GetComponent<KoubunManager>();
        text = transform.parent.gameObject;
        superChatText = text.gameObject.GetComponent<Text>();
        superChatText.text = "";
    }

    public void SuperChat()
    {
        string tagnum = this.tag;
        int num = int.Parse(tagnum);
        koubunManager.superChatNum++; //一定回数までしか打てないように。KoubunManagerに数字アリ
        if (koubunManager.superChatNum <= koubunManager.superChatLimit)
        {
            superChatText.text = superChatText.text + koubunManager.koubunArrays[num].naiyou;
        }
    }

    public void ResetSuperChat()
    {
        superChatText = GameObject.Find("Text").GetComponent<Text>();
        koubunManager.superChatNum = 0;
        superChatText.text = "";
    }

}
