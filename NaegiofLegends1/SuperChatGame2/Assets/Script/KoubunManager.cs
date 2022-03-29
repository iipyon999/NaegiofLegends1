using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KoubunManager : MonoBehaviour
{
    KoubunLibrary koubunLibrary; //構文集を持つスクリプトです

    [SerializeField]
    public List<Koubun> koubunChoiceList = new List<Koubun>(); //実際に選択された構文

    MakingSuperChat makingSuperChat;
    private ButtonMake buttonMake;
    GameObject originalButton;
    public int superChatNum = 0; //スパチャ構文を見る変数
    [SerializeField]
    public int superChatLimit; //スパチャ構文の限界数を見る変数

    public int superChatPoint;

    [SerializeField]
    public int choiseNum; //いくつチョイスするか

    private void Start()
    {
        koubunLibrary = GetComponent<KoubunLibrary>();
        makingSuperChat = GetComponent<MakingSuperChat>();
        originalButton = (GameObject)Resources.Load("Button");
        buttonMake = GetComponent<ButtonMake>();
        StartCoroutine("KoubunListCheck");
    }

    public void KoubunChoiceReset()
    {
        while (koubunChoiceList.Count > 0)
        {
            koubunChoiceList.RemoveAt(0);
        }
    }

    private void KoubunGetRandom(int start, int end, int count)
    {
        KoubunChoiceReset();
        List<int> numbers = new List<int>();

        for (int i = start; i <= end; i++)
        {
            numbers.Add(i);
        }

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, numbers.Count);
            int ransu = numbers[index];
            koubunChoiceList.Add(koubunLibrary.koubunList[ransu]);
            numbers.RemoveAt(index);
        }
    }

    public void KoubunRandomize()
    {
        KoubunGetRandom(0, koubunLibrary.koubunList.Count - 1, choiseNum);
        buttonMake.DestroyButton();
        buttonMake.ButtonMaking(originalButton);
        makingSuperChat.ResetSuperChat();
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

    IEnumerator KoubunListCheck()
    {
        while (KoubunListChecking())
        {
            yield return null;
            KoubunGetRandom(0, koubunLibrary.koubunList.Count - 1, choiseNum);
        }
    }

}
