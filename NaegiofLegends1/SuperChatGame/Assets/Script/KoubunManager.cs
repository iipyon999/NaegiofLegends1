using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KoubunManager : MonoBehaviour
{
    KoubunLibrary koubunLibrary; //構文集を持つスクリプトです

    [SerializeField]
    public Koubun[] koubunArrays = new Koubun[3]; //実際に選択された構文

    MakingSuperChat makingSuperChat;
    private ButtonMake buttonMake;
    GameObject originalButton;
    public int superChatNum = 0; //スパチャ構文を見る変数
    [SerializeField]
    public int superChatLimit ; //スパチャ構文の限界数を見る変数

    public int superChatPoint;

    private void Start()
    {
        koubunLibrary = GetComponent<KoubunLibrary>();
        makingSuperChat = GetComponent<MakingSuperChat>();
        originalButton = (GameObject)Resources.Load("Button");
        buttonMake = GetComponent<ButtonMake>();
        KoubunGetRandom(0, koubunLibrary.koubunList.Count-1, 3);
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
            koubunArrays[i] = koubunLibrary.koubunList[ransu];
            numbers.RemoveAt(index);
        }

    }

    public void KoubunRandomize()
    {
        KoubunGetRandom(0, koubunLibrary.koubunList.Count-1, 3);
        buttonMake.DestroyButton();
        buttonMake.ButtonMaking(originalButton);
        makingSuperChat.ResetSuperChat();

    }

}
