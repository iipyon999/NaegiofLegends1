using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KoubunManager : MonoBehaviour
{

    [SerializeField]
    public List<Koubun> koubunLibrary = new List<Koubun>(); //構文用ソース

    [SerializeField]
    string[] koubunName = new string[6]; //構文名前入力欄
    [SerializeField]
    string[] koubunGenre = new string[6]; //構文genre入力欄
    [SerializeField]
    string[] koubunNaiyou = new string[6]; //構文内容入力欄
    [SerializeField]
    int[] koubunPoint = new int[6];//テスト用の構文ポイント
    [SerializeField]
    public Koubun[] koubunArrays = new Koubun[3]; //実際に選択された構文

    MakingSuperChat makingSuperChat;
    private ButtonMake buttonMake;
    GameObject originalButton;
    public int superChatNum = 0;
    [SerializeField]
    public int superChatLimit = 3;

    public int superChatPoint;

    private void Start()
    {
        makingSuperChat = GetComponent<MakingSuperChat>();
        originalButton = (GameObject)Resources.Load("Button");
        buttonMake = GetComponent<ButtonMake>();
        for (int i = 0; i < 6; i++) //Libraryに構文を格納
        {
            koubunLibrary.Add(new Koubun() {
                name = koubunName[i],
                genre = koubunGenre[i],
                naiyou = koubunNaiyou[i],
                point = koubunPoint[i]
            }) ;
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

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, numbers.Count);
            int ransu = numbers[index];
            koubunArrays[i] = koubunLibrary[ransu];
            numbers.RemoveAt(index);
        }

    }

    public void KoubunRandomize()
    {
        KoubunGetRandom(0, 5, 3);
        buttonMake.DestroyButton();
        buttonMake.ButtonMaking(originalButton);
        makingSuperChat.ResetSuperChat();

    }

}
