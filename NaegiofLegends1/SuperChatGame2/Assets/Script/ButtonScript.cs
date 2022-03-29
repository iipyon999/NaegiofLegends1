using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int num;
    GameController gc;
    Menuselect menuselect;

    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        menuselect = GameObject.Find("GameController").GetComponent<Menuselect>();
    }

    public void OnClick()
    {
        var scenario01 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "STNscenario",
            Texts = new List<string>()
            {
                "STN　開始",
                "テスト2",
                "テスト3",
                "テスト4",
                "テスト5",
                "なんだコイツ！？を手に入れた"
            }
        };
        var scenario02 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "VDKscenario",
            Texts = new List<string>()
            {
                "VDKtest0",
                "VDK1",
                "VDK2",
                "VDK3",
                "VDK4",
                "心の中にバケモン居るって……を手に入れた"
            }
        };
        var scenario03 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "しすこscenario",
            Texts = new List<string>()
            {
                "しすこtest0",
                "ふらんしすこ1",
                "ふらんしすこ2",
                "ふらんしすこ3",
                "ふらんしすこ4",
                "ワンチャンは、居るのカナ？！を手に入れた"
            }
        };
        var scenario04 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "しすこscenario",
            Texts = new List<string>()
            {
                "しすこtest0",
                "ふらんしすこ1",
                "ふらんしすこ2",
                "ふらんしすこ3",
                "ふらんしすこ4",
                "ワンチャンは、居るのカナ？！を手に入れた"
            }
        };
        var scenario05 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "しすこscenario",
            Texts = new List<string>()
            {
                "しすこtest0",
                "ふらんしすこ1",
                "ふらんしすこ2",
                "ふらんしすこ3",
                "ふらんしすこ4",
                "ワンチャンは、居るのカナ？！を手に入れた"
            }
        };
        var scenario06 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "しすこscenario",
            Texts = new List<string>()
            {
                "しすこtest0",
                "ふらんしすこ1",
                "ふらんしすこ2",
                "ふらんしすこ3",
                "ふらんしすこ4",
                "ワンチャンは、居るのカナ？！を手に入れた"
            }
        };

        switch (num)
        {
            case 1:
                gc.SetScenario(scenario01);
                break;
            case 2:
                gc.SetScenario(scenario02);
                break;
            case 3:
                gc.SetScenario(scenario03);
                break;
            case 4:
                gc.SetScenario(scenario04);
                break;
            case 5:
                gc.SetScenario(scenario05);
                break;
            case 6:
                gc.SetScenario(scenario06);
                break;
        }
        gc.buttonPanel.SetActive(false);
        gc.BackSample = true;
    }
}

