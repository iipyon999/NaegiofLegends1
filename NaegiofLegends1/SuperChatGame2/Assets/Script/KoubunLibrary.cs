using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Koubun
{
    public int ID;//構文のID
    public string name; //構文の名前
    public string scenarioID; //構文のジャンル。手にいれられる場所などに依存？
    public string naiyou; //構文の中身
    public int point;
    /*
    public int ojisanPoint; //オジサンポイント
    public int kimoPoint; //気持ち悪さを見るキモポイント
    public int yabaiPoint;　//ヤバさをみるヤバポイント
    */
}

public class KoubunLibrary : MonoBehaviour
{
    [SerializeField]
    public List<Koubun> koubunList = new List<Koubun>(); //構文用ソース
    public string[,] koubunTextDataList ;//データから読み込んだ構文を一度格納する場所 
    TextLoad textLoad; //データを読み込む関数

    private void Start()
    {
        textLoad = GameObject.Find("GameController").GetComponent<TextLoad>();
        koubunTextDataList = textLoad.TextLoading("KoubunDataList"); //テキストの名前を入力

        for (int i = 0; i < koubunTextDataList.GetLength(0); i++)
        {
            koubunList.Add(new Koubun());
            for (int n = 0; n < koubunTextDataList.GetLength(1); n++)
            {
                switch (n) //必ずKoubunクラスの要素順と一致させること！！！
                {
                    case 0:
                        koubunList[i].ID = int.Parse(koubunTextDataList[i, n]);
                        break;
                    case 1:
                        koubunList[i].name = koubunTextDataList[i, n];
                        break;
                    case 2:
                        koubunList[i].scenarioID = koubunTextDataList[i, n];
                        break;
                    case 3:
                        koubunList[i].naiyou = koubunTextDataList[i, n];
                        break;
                    case 4:
                        koubunList[i].point = int.Parse(koubunTextDataList[i, n]);
                        break;
                    default: Debug.Log("error");
                        break;
                }
            }
        
        }
    }


}

