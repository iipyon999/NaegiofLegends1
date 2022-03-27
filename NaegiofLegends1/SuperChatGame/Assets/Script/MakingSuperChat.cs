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
    ResponseManager responseManager;

    private void Start()
    {
        koubunM = GameObject.Find("KoubunManager");
        koubunManager = koubunM.GetComponent<KoubunManager>();
        responseManager = GameObject.Find("ResponseManager").GetComponent<ResponseManager>();
        text = GameObject.Find("Text");
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
            koubunManager.superChatPoint += koubunManager.koubunArrays[num].point;
        }
    }

    public void ResetSuperChat()
    {
        superChatText = GameObject.Find("Text").GetComponent<Text>();
        koubunManager.superChatNum = 0;
        koubunManager.superChatPoint = 0;
        superChatText.text = "";
    }

    public void SendSuperChat()
    {
        superChatText = GameObject.Find("Text").GetComponent<Text>();
        responseManager.Response(koubunManager.superChatPoint);
        koubunManager.superChatNum = 0;
        koubunManager.superChatPoint = 0;
        superChatText.text = "";
    }

}
