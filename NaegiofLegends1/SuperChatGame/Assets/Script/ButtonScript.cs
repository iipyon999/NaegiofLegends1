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
                "なんだコイツを手に入れた"
            }
        };

        var scenario02 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "VDKscenario",
            Texts = new List<string>()
            {
                "VDKtest",
                "今配信しているのは……",
                "Stylishnoodleと……",
                "VDKと……",
                "ふらんしすこ、この三人か……",
                "どの配信者"
            }
        };
        var scenario03 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "しすこscenario",
            Texts = new List<string>()
            {
                "しすこtest",
                "今配信しているのは……",
                "Stylishnoodleと……",
                "VDKと……",
                "ふらんしすこ、この三人か……",
                "どの配信者"
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

