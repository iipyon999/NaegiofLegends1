using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Koubun
{
    public string name; //構文の名前
    public string genre; //構文のジャンル。手にいれられる場所などに依存？
    public string naiyou; //構文の中身
    public int ojisanPoint; //オジサンポイント
    public int kimoPoint; //気持ち悪さを見るキモポイント
    public int yabaiPoint;　//ヤバさをみるヤバポイント
}

public class KoubunManager : MonoBehaviour
{
    [SerializeField]
    string[] koubunName = new string[6]; //構文名前入力欄
    [SerializeField]
    string[] koubunGenre = new string[6]; //構文genre入力欄
    [SerializeField]
    string[] koubunNaiyou = new string[6]; //構文内容入力欄
    public Koubun[] koubunLibrary = new Koubun[6]; //構文用ソース
    [SerializeField]
    public Koubun[] koubunArrays = new Koubun[3]; //実際に選択された構文

    private void Start()
    {

        for (int i = 0; i < 5; i++) //Libraryに構文を格納
        {
            koubunLibrary[i].name = koubunName[i];
            koubunLibrary[i].genre = koubunGenre[i];
            koubunLibrary[i].naiyou = koubunNaiyou[i];
        }
        KoubunGetRandom(0, 5, 3);
    }

    private void KoubunGetRandom(int start, int end, int count)
    {

        List<int> numbers = new List<int>();

        for (int i = start; i <= end; i++)
        {
            numbers.Add(i);
        }

        for (int i = 1; i < count; i++)
        {
            int index = Random.Range(0, numbers.Count);
            int ransu = numbers[index];
            koubunArrays[i] = koubunLibrary[ransu];
            Debug.Log(koubunArrays[i].name);
            numbers.RemoveAt(index);
        }

    }



    private void KoubunRandomize()
    {
        KoubunGetRandom(0, 5, 3);
    }

}
