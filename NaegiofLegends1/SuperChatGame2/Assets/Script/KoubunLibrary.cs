using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Koubun
{
    public int ID;//構文のID
    public string name; //構文の名前
    public string genre; //構文のジャンル。手にいれられる場所などに依存？
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
    public string[] textMessage; //テキストの加工前の一行を入れる変数
    public string[,] textWords; //テキストの複数列を入れる2次元は配列 

    public int rowLength; //テキスト内の行数を取得する変数
    public int columnLength; //テキスト内の列数を取得する変数

    [SerializeField]
    public List<Koubun> koubunList = new List<Koubun>(); //構文用ソース

    private void Start()
    {
        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load("KoubunDataList", typeof(TextAsset)) as TextAsset; //Resourcesフォルダから対象テキストを取得
        string TextLines = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる

        //Splitで一行づつを代入した1次配列を作成
        textMessage = TextLines.Split('\n'); //

        //行数と列数を取得
        columnLength = textMessage[0].Split('\t').Length;
        rowLength = textMessage.Length;

        //2次配列を定義
        textWords = new string[rowLength, columnLength];

        for (int i = 0; i < rowLength; i++)
        {
            string[] tempWords = textMessage[i].Split('\t'); //textMessageをカンマごとに分けたものを一時的にtempWordsに代入
            koubunList.Add(new Koubun());
            for (int n = 0; n < columnLength; n++)
            {
                textWords[i, n] = tempWords[n]; //2次配列textWordsにカンマごとに分けたtempWordsを代入していく
                switch (n) //必ずKoubunクラスの要素順と一致させること！！！
                {
                    case 0:
                        koubunList[i].ID = int.Parse(textWords[i, n]);
                        break;
                    case 1:
                        koubunList[i].name = textWords[i, n];
                        break;
                    case 2:
                        koubunList[i].genre = textWords[i, n];
                        break;
                    case 3:
                        koubunList[i].naiyou = textWords[i, n];
                        break;
                    case 4:
                        koubunList[i].point = int.Parse(textWords[i, n]);
                        break;
                    default: Debug.Log("error");
                        break;
                }
            }
        
        }
    }


}

