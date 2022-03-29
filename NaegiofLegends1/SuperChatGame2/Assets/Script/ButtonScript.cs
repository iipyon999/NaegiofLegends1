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
            ScenarioID = "ぺこらscenario",
            Texts = new List<string>()
            {
                "ぺこーらテスト",
                "ぺこーらテスト1",
                "ぺこーらテスト2",
                "ぺこーらテスト3",
                "ぺこーらテスト4",
                "ぺコーラいつもありがとう！を手に入れた"
            }
        };
        var scenario05 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "ひろゆきscenario",
            Texts = new List<string>()
            {
                "ひろゆきtest0",
                "ひろゆき1",
                "ひろゆき2",
                "ひろゆき3",
                "ひろゆき4",
                "なんかそういうデータあるんすか？を手に入れた"
            }
        };
        var scenario06 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "パイギscenario",
            Texts = new List<string>()
            {
                "パイギ0",
                "パイギ1",
                "パイギ2",
                "パイギ3",
                "パイギ4",
                "俺はスパイギア。を手に入れた"
            }
        };
        var scenario07 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "淫夢scenario",
            Texts = new List<string>()
            {
                "淫夢0",
                "淫夢1",
                "淫夢2",
                "淫夢3",
                "淫夢4",
                "ケツ舐められたことあんのかよ誰かによ を手に入れた"
            }
        };
        var scenario08 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "ク☆scenario",
            Texts = new List<string>()
            {
                "クッキー0",
                "クッキー1",
                "クッキー2",
                "クッキー3",
                "クッキー4",
                "今日もいい天気☆を手に入れた"
            }
        };
        var scenario09 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "加藤純一scenario",
            Texts = new List<string>()
            {
                "じゅん0",
                "じゅん1",
                "じゅん2",
                "じゅん3",
                "じゅん4",
                "だよなぁ？！ を手に入れた"
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
            case 7:
                gc.SetScenario(scenario07);
                break;
            case 8:
                gc.SetScenario(scenario08);
                break;
            case 9:
                gc.SetScenario(scenario09);
                break;
        }
        gc.buttonPanel.SetActive(false);
        gc.BackSample = true;
    }
}

