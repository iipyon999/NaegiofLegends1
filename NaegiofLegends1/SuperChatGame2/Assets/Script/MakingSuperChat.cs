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
    ButtonMake buttonMake;

    private void Start()
    {
        koubunM = GameObject.Find("KoubunManager");
        koubunManager = koubunM.GetComponent<KoubunManager>();
        buttonMake = koubunM.GetComponent<ButtonMake>();
        responseManager = GameObject.Find("ResponseManager").GetComponent<ResponseManager>();
        text = GameObject.Find("SuperChatText");
        superChatText = text.gameObject.GetComponent<Text>();
        superChatText.text = "";
    }

    public void SuperChat()
    {
        string chekingKoubunName;
        koubunManager.superChatNum++; //一定回数までしか打てないように。KoubunManagerに数字アリ
        if (koubunManager.superChatNum <= koubunManager.superChatLimit)
        {
            for(int i = 0; i < koubunManager.koubunChoiceList.Count; i++)
            {
                chekingKoubunName = koubunManager.koubunChoiceList[i].name;
                GameObject buttons = this.gameObject;
                Text text = buttons.transform.Find("Text").gameObject.GetComponent<Text>();
                if (text.text == chekingKoubunName)
                {
                    superChatText.text = superChatText.text + koubunManager.koubunChoiceList[i].naiyou;
                    koubunManager.superChatPoint += koubunManager.koubunChoiceList[i].point;
                }
            }        }
    }

    public void ResetSuperChat()
    {
        superChatText = GameObject.Find("SuperChatText").GetComponent<Text>();
        koubunManager.superChatNum = 0;
        koubunManager.superChatPoint = 0;
        superChatText.text = "";
    }

    public void SendSuperChat()
    {
        superChatText = GameObject.Find("SuperChatText").GetComponent<Text>();
        responseManager.Response(koubunManager.superChatPoint);
        koubunManager.superChatNum = 0;
        koubunManager.superChatPoint = 0;
        superChatText.text = "";
    }

}
