using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KoubunManager : MonoBehaviour
{
    KoubunLibrary koubunLibrary; //構文集を持つスクリプトです
    GameController gameController;

    [SerializeField]
    public static List<Koubun> koubunChoiceList = new List<Koubun>(); //実際に選択された構文

    public int superChatNum = 0; //スパチャ構文を見る変数
    [SerializeField]
    public int superChatLimit; //スパチャ構文の限界数を見る変数

    public int superChatPoint; //スパチャのポイントを見る


    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        koubunLibrary = GetComponent<KoubunLibrary>();
    }

    public void KoubunLoad()
    {
        superChatNum = 0;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if (gameController.currentScenario != null)
        {
            bool koubunCheck = false;
            string currentScenarioID = gameController.currentScenario.ScenarioID;
            for(int i = 0; i < koubunChoiceList.Count; i++) //選択された構文リストを探すループ
            {
                //選択された構文リストの中に、現在のシナリオと同じIDが存在する場合はチェックしておきたい
                if(currentScenarioID == koubunChoiceList[i].scenarioID) 
                {
                    koubunCheck = true;
                }
            }
            if(koubunCheck == false) //もしfalseなら、つまり選択された構文リストの中に現在のシナリオと同じIDが存在しない場合
            {
                //構文リストの中から、現在のシナリオと同じIDを持つものを探して格納したい
                for(int i = 0; i< koubunLibrary.koubunList.Count; i++) 
                {
                    if(currentScenarioID == koubunLibrary.koubunList[i].scenarioID)
                    {
                        koubunChoiceList.Add(koubunLibrary.koubunList[i]);
                    }
                }
            }
        }
    }

    public bool KoubunListChecking() //構文リストが正しく存在しているかどうかを確認する関数
    {
        bool listExistence;
        if (koubunLibrary.koubunList == null || koubunLibrary.koubunTextDataList == null)
            listExistence = false;
        else
            listExistence = true;
        if (listExistence == false || koubunLibrary.koubunTextDataList.GetLength(0) != koubunLibrary.koubunList.Count)
            return true;
        else
            return false;
    }

}
