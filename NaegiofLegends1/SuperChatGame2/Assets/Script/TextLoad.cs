using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoad : MonoBehaviour
{
    public string[,] TextLoading(string textName)
    {
        string[] textMessage; //テキストの加工前の一行を入れる変数
        string[,] textWords; //テキストの複数列を入れる2次元は配列 

        int rowLength; //テキスト内の行数を取得する変数
        int columnLength; //テキスト内の列数を取得する変数


        TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
        textasset = Resources.Load(textName, typeof(TextAsset)) as TextAsset; //Resourcesフォルダから対象テキストを取得
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

            for (int n = 0; n < columnLength; n++)
            {
                textWords[i, n] = tempWords[n]; //2次配列textWordsにカンマごとに分けたtempWordsを代入していく
            }
        }

        return textWords;
    }
}
