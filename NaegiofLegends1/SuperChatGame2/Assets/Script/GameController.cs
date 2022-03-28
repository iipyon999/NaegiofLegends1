using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    [SerializeField]
    Text scenarioText; //シナリオを表示するための場所
    List<Scenario> scenarios = new List<Scenario>();
    //bool panelkirikae = false;
    [SerializeField]
    public Scenario currentScenario; //public化して他のところから参照できるように

    public int index = 0;

    void Start()
    {
        if (GameObject.FindWithTag("ScenarioText") == true)
        {
            scenarioText = GameObject.FindWithTag("ScenarioText").GetComponent<Text>();
        }
        DontDestroyOnLoad(this); //色んなシーンで使えるように
        StartingScenarioSet(); //始まりのシナリオをセットするための関数
    }

    void StartingScenarioSet()
    {
        var startingScenario = new Scenario(); //始まりのシナリオを格納するための場所
        string activeSceneName = SceneManager.GetActiveScene().name; //現在のシーンの名前

        switch (activeSceneName)
        {
            case "TwitchScene": //ツイッチシーンの始まりのシナリオ
                startingScenario = new Scenario()
                {
                    ScenarioID = "scenarioTwitchStart",
                    Texts = new List<string>()
                    {
                "配信者が集まるプラットフォーム、Twitchとやらを見てみよう",
                "今配信しているのは……",
                "Stylishnoodleと……",
                "VDKと……",
                "ふらんしすこ、この三人か……",
                "どの配信者を見てみようか？"
                    }
                };
                break;

            case "YoutubeScene": //Youtubeシーンの始まりのシナリオ
                startingScenario = new Scenario()
                {
                    ScenarioID = "scenarioYoutubeStart",
                    Texts = new List<string>()
            {
                "動画投稿者の集まるプラットフォーム、Youtubeを見てみようカナ？",
                "新しく動画を投稿したのは……",
                "ぺこーらと……",
                "ひろきと……",
                "スッパイギア、この三人か……",
                "どの配信者を見てみようか？"
            }
                };

                break;
            case "NiconicoScene": //Niconicoシーンの始まりのシナリオ
                startingScenario = new Scenario()
                {
                    ScenarioID = "scenarioNiconicoStart",
                    Texts = new List<string>()
            {
                "アンダーグラウンドな動画プラットフォーム、ニコニコ動画を見てみようカナ？",
                "最近人気なのは……",
                "淫夢と……",
                "クッキー☆と……",
                "加藤純一か……",
                "どの動画を見てみようか？"
            }
                };

                break;
            default:
                startingScenario = null;
                break;
        }

        SetScenario(startingScenario);

    }

    void Update()
    {
        if (currentScenario != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetNextMessage();
            }
        }
    }

    public void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        scenarioText.text = currentScenario.Texts[0];
    }

    public void SetNextMessage()
    {
        if (currentScenario.Texts.Count > index + 1)
        {
            index++;
            scenarioText.text = currentScenario.Texts[index];
        }
        else
        {
            //Twitchbotan();
            ExitScenario();
        }
    }

    public void ExitScenario()
    {
        scenarioText.text = "";
        index = 0;
        if (string.IsNullOrEmpty(currentScenario.NextScenarioID))
        {
            currentScenario = null;
        }
        else
        {
            var nextScenario = scenarios.Find
                (s => s.ScenarioID == currentScenario.NextScenarioID);
            currentScenario = nextScenario;
        }
    }

    /*
    public void Twitchbotan()
    {
        if (panelkirikae == false)
        {
            panel.SetActive(true);
        }
        panelkirikae = true;
    }
    */
}

