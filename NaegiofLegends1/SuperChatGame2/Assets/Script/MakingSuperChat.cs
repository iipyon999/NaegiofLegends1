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

    [SerializeField]
    public List<Koubun> nowSuperChat = new List<Koubun>(); //実際に選択された構文

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

    public void SuperChat(GameObject button)
    {
        string chekingKoubunName;
        koubunManager.superChatNum++; //一定回数までしか打てないように。KoubunManagerに数字アリ
        if (koubunManager.superChatNum <= koubunManager.superChatLimit)
        {
            for (int i = 0; i < KoubunManager.koubunChoiceList.Count; i++)
            {
                chekingKoubunName = KoubunManager.koubunChoiceList[i].name;
                Text text = button.transform.Find("Text").gameObject.GetComponent<Text>();
                if (text.text == chekingKoubunName)
                {
                    Koubun koubun = KoubunManager.koubunChoiceList[i];
                    Debug.Log(koubun);
                    nowSuperChat.Add(koubun);
                    Debug.Log(nowSuperChat.Count);
                    superChatText.text = superChatText.text + KoubunManager.koubunChoiceList[i].naiyou;
                }
            }
        }
    }

    public void ResetSuperChat()
    {
        superChatText = GameObject.Find("SuperChatText").GetComponent<Text>();
        koubunManager.superChatNum = 0;
        nowSuperChat.Clear();
        superChatText.text = "";
    }

    public void SendSuperChat()
    {
        gameController.superChatSendCount++;
        if(gameController.superChatSendCount > 0)
        {
            endingButton.SetActive(true);
        }
        OjisanMoneyCheck();
        StartCoroutine("ResponseMake");

    }

    void OjisanMoneyCheck()
    {
        ojisanMoneyStock = ojisanActionManager.ojisanMoney - (gameController.superChatSendCount * 10000);
        OjisanMoneyText.text = "おぢさんのおサイフの中身\nｷｬｯ(/ω＼)\n" + ojisanMoneyStock;
        if (ojisanMoneyStock <= 0)
        {
            SendText.text = "おサイフカラッポ（涙）";
            Destroy(GetComponent<MakingSuperChat>());
        }
    }

    IEnumerator ResponseMake()
    {
        responseManager.ResponseMaking();
        while(responseManager.checking == false)
        {
            yield return null;
        }
        ResetSuperChat();
    }
}
