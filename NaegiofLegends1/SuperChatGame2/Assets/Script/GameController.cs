using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    KoubunManager koubunManager;

    [SerializeField]
    Text scenarioText; //シナリオを表示するための場所
    List<Scenario> scenarios = new List<Scenario>();
    bool buttonPanelChange = false; //ボタンパネルを表示させるかどうかを判断するための変数
    [SerializeField]
    public Scenario currentScenario; //public化して他のところから参照できるように
    private GameObject canvas; //キャンバスを取得
    public GameObject buttonPanel; // ボタン用のパネルを取得
    public bool BackSample;
    Menuselect menuselect;

    public int index = 0;

    void Start()
    {
        DontDestroyOnLoad(this); //色んなシーンで使えるように
        StartingScenarioSet(); //始まりのシナリオをセットするための関数
        menuselect = GetComponent<Menuselect>();
        koubunManager = GameObject.Find("KoubunManager").GetComponent<KoubunManager>();
    }

    public void StartingScenarioSet()
    {
        buttonPanelChange = false; //呼ばれるたびに一旦falseにする
        BackSample = false;   //シーンが変わるたびに一旦Falseにする

        if (GameObject.Find("Canvas") == true) //キャンバスがあるかどうかを確認する
        {
            canvas = GameObject.Find("Canvas"); //キャンバスを取得する
        }

        if (canvas.transform.Find("ButtonPanel") == true) //ボタンパネルがあるかどうかを確認する
        {
            buttonPanel = canvas.transform.Find("ButtonPanel").gameObject;
            //ボタンパネルはキャンバスの子供なので、親を経由すれば非アクティブで取得できる
        }

        if (GameObject.Find("ScenarioText") == true) //シナリオテキストがあるかどうかを確認する
        {
            scenarioText = GameObject.Find("ScenarioText").GetComponent<Text>(); //シナリオテキストを取得する
        }

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

            case "StartingScene":
                startingScenario = new Scenario()
                {
                    ScenarioID = "scenarioStartingStart",
                    Texts = new List<string>()
                    {
                        "テスト文章、ダヨ(^_-)-☆",
                        "ゆっくり試していってネ！" ,
                        "ってな（藁）"
                    },
                    Options = new List<string>() //特殊なオプション
                    {
                        "GoSample"
                    }
                };
                break;
            case "EndingScene": //エンディング用シーンのシナリオ
                startingScenario = new Scenario()
                {
                    ScenarioID = "scenarioEndingStart",
                    Texts = new List<string>()
                    {
                        "スパチャ、投げちゃった、ネ！",
                        "一旦ここでオワリ……",
                        "ダヨ(^_-)-☆",
                        "終"
                    },
                    Options = new List<string>() //特殊なオプション
                    {
                        "GoStart"
                    },
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

    void OptionCheck(string options)
    {
        switch (options)
        {
            case "GoSample":
                menuselect.StartGame(1);
                break;
            case "GoStart":
                menuselect.StartGame(0);
                break;
        }
    }

    public void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        if (scenarioText != null)
        {
            scenarioText.text = currentScenario.Texts[0];
            koubunManager.KoubunLoad();
        }
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
            buttonPanelActivator();
            ExitScenario();
            if (BackSample == true)
            {
                menuselect.StartGame(1);
            }
        }
    }

    public void ExitScenario()
    {
        scenarioText.text = "";
        index = 0;
        string optionCheck;
        if (currentScenario.Options != null)
        {
            optionCheck = currentScenario.Options[0];
        }
        else
        {
            optionCheck = "null";
        }
        Debug.Log(optionCheck);
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
        if (optionCheck != "null")
        {
            OptionCheck(optionCheck);
        }
    }

    public void buttonPanelActivator()
    {
        if (buttonPanel != null)
        {
            if (buttonPanelChange == false)
            {
                buttonPanel.SetActive(true);
            }
            buttonPanelChange = true;
        }
    }
}

