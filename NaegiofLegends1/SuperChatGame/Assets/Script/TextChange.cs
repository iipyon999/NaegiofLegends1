using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    [SerializeField]
    Text textFrame;

    private void Start()
    {
        textFrame.text = "";
    }

    public void Pekora()
    {
        textFrame.text = textFrame.text + "ぺこーらいつもありがとう！";
    }

    public void Chicken()
    {
        textFrame.text = textFrame.text + "チキン冷めちゃった……";
    }

    public void TaigainiSayyo()
    {
        textFrame.text = textFrame.text + "心の中にバケモン居るって……大概にするのは、俺の方やった";
    }
}
