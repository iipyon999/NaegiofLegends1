using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Response
{
    public int ID;
    public string naiyou;
}

public class ResponseManager : MonoBehaviour
{
    public Text responseText;
    TextLoad textLoad; //データを読み込む関数
    MakingSuperChat makingSuperChat;
    KoubunManager koubunManager;

    string[,] responseDataList; //データから読み込んだ構文を一度格納する場所
    [SerializeField]
    public List<Response> responseTextList = new List<Response>();

    int tiredPoint = 0; //疲労度
    int fukaiPoint = 0;  //不快度
    public bool checking;

    private void Start()
    {
        makingSuperChat = GameObject.Find("SuperChatButtonManager").GetComponent<MakingSuperChat>();
        responseText = GameObject.Find("CommentText").GetComponent<Text>(); //くれ子ちゃんのコメント
        textLoad = GameObject.Find("GameController").GetComponent<TextLoad>();
        koubunManager = GameObject.Find("KoubunManager").GetComponent<KoubunManager>();
        responseDataList = textLoad.TextLoading("ResponseList");
        for (int i = 0; i < responseDataList.GetLength(0); i++)
        {
            responseTextList.Add(new Response());
            for(int n = 0; n < responseDataList.GetLength(1); n++)
            {
                switch(n) //レスポンスクラスの要素順と一致させること
                {
                    case 0:
                        responseTextList[i].ID = int.Parse(responseDataList[i, n]);
                        break;
                    case 1:
                        responseTextList[i].naiyou = responseDataList[i, n];
                        break;
                }
            }
        }
    }

    public void ResponseMaking() //必ずMakingSuperChatから呼べるようにすること
    {
        checking = false;
        int sumFunnyPoint=0;
        int sumKimoPoint=0;
        bool bot = true;
        int BANCount = 0;
        int thanksCount = 0;
        int selfCount =0;
        int cultCount = 0;
        List<int> botCount = new List<int>();

        //makingSuperChat.nowSuperChatが現在呼び出されているスパチャ集
        for (int i = 0; i < makingSuperChat.nowSuperChat.Count; i++)
        {
            sumFunnyPoint += makingSuperChat.nowSuperChat[i].funnyPoint;
            sumKimoPoint += makingSuperChat.nowSuperChat[i].kimoPoint;
        }

        //以降一生分岐を書き続ける。ResponseList内のIDと実際のIndexはID-1の関係にあることに注意
        if(makingSuperChat.nowSuperChat.Count == 0)
        {
            //無言スパチャ
            responseText.text = responseTextList[0].naiyou;
            goto END;
        }
        if(sumFunnyPoint > sumKimoPoint)
        {
            //普通に感謝
            responseText.text = responseTextList[1].naiyou;
            goto END;
        }

        for(int i = 0; i < makingSuperChat.nowSuperChat.Count; i++)
        {
            if(makingSuperChat.nowSuperChat[i].genre == "thanks")
            {
                thanksCount++;
            }
            if (makingSuperChat.nowSuperChat[i].genre == "self")
            {
                selfCount++;
            }
            if (makingSuperChat.nowSuperChat[i].genre == "cult")
            {
                cultCount++;
            }
            if(makingSuperChat.nowSuperChat[i].genre == "BAN")
            {
                BANCount++;
            }
            botCount.Add(makingSuperChat.nowSuperChat[i].ID);
        }
        for(int i = 0; i < botCount.Count; i++)
        {
            if(botCount.Count < 2)
            {
                bot = false;
            }
            if (botCount[0] != botCount[i])
            {
                bot = false;
            }
        }
        if(thanksCount == makingSuperChat.nowSuperChat.Count)
        {
            //めっちゃ感謝
            responseText.text = responseTextList[4].naiyou;
            goto END;
        }
        if(selfCount == makingSuperChat.nowSuperChat.Count)
        {
            //自分語りマン
            responseText.text = responseTextList[8].naiyou;
            goto END;
        }
        if(cultCount == makingSuperChat.nowSuperChat.Count)
        {
            //くれこ最強！
            responseText.text = responseTextList[3].naiyou;
            goto END;
        }
        if(BANCount == makingSuperChat.nowSuperChat.Count)
        {
            //BAN
            responseText.text = responseTextList[11].naiyou;
            goto END;
        }
        if(bot == true)
        {
            //bot
            responseText.text = responseTextList[13].naiyou;
            goto END;
        }
        if (sumFunnyPoint * 5 < sumKimoPoint)
        {
            //ガチでキモイ
            responseText.text = responseTextList[9].naiyou;
            goto END;
        }
        if (sumFunnyPoint * 4 < sumKimoPoint)
        {
            //大分キモイ
            responseText.text = responseTextList[7].naiyou;
            goto END;
        }
        if (sumFunnyPoint * 3 < sumKimoPoint)
        {
            //結構キモイ
            responseText.text = responseTextList[6].naiyou;
            goto END;
        }
        if (sumFunnyPoint*2 < sumKimoPoint)
        {
            //まあまあキモイ
            responseText.text = responseTextList[5].naiyou;
            goto END;
        }

    END:
        checking = true;

    }




}
