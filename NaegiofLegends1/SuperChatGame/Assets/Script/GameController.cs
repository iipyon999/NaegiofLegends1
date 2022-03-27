using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panel;
    [SerializeField]
    Text scenarioMessage;
    List<Scenario> scenarios = new List<Scenario>();

    Scenario currentScenario;
    int index = 0;

    public class Scenario
    {
        public string ScenarioID;
        public List<string> Texts;
        public List<string> Options;
        public string NextScenarioID;
    }

    void Start()
    {
        var scenario01 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "scenario01",
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

        SetScenario(scenario01);
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

    void SetScenario(Scenario scenario)
    {
        currentScenario = scenario;
        scenarioMessage.text = currentScenario.Texts[0];
    }

    void SetNextMessage()
    {
        if (currentScenario.Texts.Count > index + 1)
        {
            index++;
            scenarioMessage.text = currentScenario.Texts[index];
        }
        else
        {
            Twitchbotan();
        }
    }

    void ExitScenario()
    {
        scenarioMessage.text = "";
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
    void Twitchbotan()
    {
        panel.SetActive(true);
    }
}