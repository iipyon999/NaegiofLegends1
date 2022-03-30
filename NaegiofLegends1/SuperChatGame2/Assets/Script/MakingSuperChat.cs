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
    GameController gameController;
    OjisanActionManager ojisanActionManager;
    GameObject canvas;

    GameObject endingButton;
    Text OjisanMoneyText;

    Text SendText;
    int superChatCount;
    int ojisanMoneyStock;

    private void Start()
    {
        koubunM = GameObject.Find("KoubunManager");
        koubunManager = koubunM.GetComponent<KoubunManager>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        buttonMake = koubunM.GetComponent<ButtonMake>();
        responseManager = GameObject.Find("ResponseManager").GetComponent<ResponseManager>();
        text = GameObject.Find("SuperChatText");
        canvas = GameObject.Find("Canvas");
        ojisanActionManager = GameObject.Find("OjisanActionManager").GetComponent<OjisanActionManager>();
        endingButton = canvas.transform.Find("EndingButton").gameObject;
        OjisanMoneyText = GameObject.Find("OjisanMoneyText").GetComponent<Text>();
        superChatText = text.gameObject.GetComponent<Text>();
        superChatText.text = "";
        SendText = GameObject.Find("SendText").GetComponent<Text>();
        OjisanMoneyCheck();
        if (gameController.superChatSendCount > 0)
        {
            endingButton.SetActive(true);
        }
    }

    public void SuperChat()
    {
        string chekingKoubunName;
        koubunManager.superChatNum++; //一定回数までしか打てないように。KoubunManagerに数字アリ
        if (koubunManager.superChatNum <= koubunManager.superChatLimit)
        {
            for (int i = 0; i < KoubunManager.koubunChoiceList.Count; i++)
            {
                chekingKoubunName = KoubunManager.koubunChoiceList[i].name;
                GameObject buttons = this.gameObject;
                Text text = buttons.transform.Find("Text").gameObject.GetComponent<Text>();
                if (text.text == chekingKoubunName)
                {
                    superChatText.text = superChatText.text + KoubunManager.koubunChoiceList[i].naiyou;
                    koubunManager.superChatPoint += KoubunManager.koubunChoiceList[i].point;
                }
            }
        }
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
        gameController.superChatSendCount++;
        if(gameController.superChatSendCount > 0)
        {
            endingButton.SetActive(true);
        }
        OjisanMoneyCheck();
    }

    void OjisanMoneyCheck()
    {
        ojisanMoneyStock = ojisanActionManager.ojisanMoney - (gameController.superChatSendCount * 10000);
        OjisanMoneyText.text = "おぢさんのおサイフの中身(/ω＼)\n" + ojisanMoneyStock;
        if (ojisanMoneyStock <= 0)
        {
            SendText.text = "お金なくなっちゃった（涙）";
            Destroy(GetComponent<MakingSuperChat>());
        }

    }
}
