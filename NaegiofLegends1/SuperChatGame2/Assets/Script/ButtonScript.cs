using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public int num;
    public GameController gc;
    public void OnClick()
    {
        gc.index = 0;
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
        gc.index = 0;
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
        gc.index = 0;
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
        }
         gc.panel.SetActive(false);
    }

}

