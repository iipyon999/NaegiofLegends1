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
                "FPS界の重鎮と言われている、Stylishnoodleを見てみよう。",
                "勝っても感謝、負けても感謝、それ即ち人として強い。",
                "感謝の心を忘れない配信者……ってコト！？ﾜｯ･･･ｽｺﾞｯ!",
                "――――Stylishnoodleの配信を楽しんだ。",
                "『なんだコイツ！？』を手に入れた"
            }
        };
        var scenario02 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "VDKscenario",
            Texts = new List<string>()
            {
                "VDKという配信者を見てみよう。",
                "おいコイツ面白すぎやって、流石は最前線を走る配信者やなぁ。",
                "あー最高や、あーもう最高や。エグいって。",
                "――――VDKの配信を楽しんだ。",
                "心の中にバケモン居るって……を手に入れた"
            }
        };
        var scenario03 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "しすこscenario",
            Texts = new List<string>()
            {
                "FPS配信者、ふらんしすこを見てみようカナ？",
                "年齢が近いのかナ？おぢさんの文章と喋り方が似てて、見てて楽しかったよ(^_^)♡",
                "――――ふらんしすこの配信を楽しんだ",
                "ワンチャンは、居るのカナ？を手に入れた"
            }
        };
        var scenario04 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "ぺこらscenario",
            Texts = new List<string>()
            {
                "他のVtuberの配信を見てみんとする。",
                "今回は、大手事務所に所属するぺこーらというVtuberを見てみる。",
                "しかし、これはあくまで偵察、……そう、おじさんはくれ子ﾁｬﾝ一筋だからネ❕❕(^_^)♡",
                "────うさだぺこーらの配信を楽しんだ。",
                "ぺコーラいつもありがとう！を手に入れた"
            }
        };
        var scenario05 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "ひろゆきscenario",
            Texts = new List<string>()
            {
                "スパチャが良く飛んでいるらしいひろゆきの配信を見た。",
                "まずVtuberについてなんですけど、これはもう市民権を得たといっても過言ではないんですよね。",
                "CDを出しているVtuberも居る訳ですし、Vtuberという名称もYoutubeを見ていれば目に入る機会はあります。",
                "そもそもオタクしか見てないとか言ってる人も居ますけど、なんかそういうデータあるんすか？",
                "Vtuber、特にくれ子ﾁｬﾝの魅力に気付いてない人、はい、これ全員バカです。",
                "――――ひろゆきの配信を楽しんだ",
                "なんかそういうデータあるんすか？を手に入れた"
            }
        };
        var scenario06 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "パイギscenario",
            Texts = new List<string>()
            {
                "世界を射抜くイケメンスナイパー、スッパイギアの動画を見た。",
                "「春になったらサ、バーベキュー配信でもしようヨ。昔配信でやったのが懐かしいナ……。」",
                "いつものようにコメントをするが、くれ子ﾁｬﾝはゲームをしているだけで、全く取り合わない。",
                "真っ暗な部屋の中で、冷たい機械音だけが鳴り続く。",
                "「また来るわ。いい加減コメント見ろよ」そう言い残し、席を立つ。俺はおじさん。",
                "――――スッパイギアの動画を楽しんだ。",
                "俺はおじさん。を手に入れた"
            }
        };
        var scenario07 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "淫夢scenario",
            Texts = new List<string>()
            {
                "ネットのおもちゃを見てみよう。",
                "淫夢ってのは、一時期ネットで異常な流行を見せていたホ〇ビの総称らしいね、あーもうめちゃくちゃだよ。",
                "大胆な告白は男の子の特権らしいから、おじさんもくれ子ﾁｬﾝに告白しちゃおうカナ？（＾_＾）",
                "お前の事が好きだったんだよ！（迫真）ってね（照）",
                "――――淫夢動画を楽しんだ。",
                "ケツ舐められたことあんのかよ誰かによ を手に入れた"
            }
        };
        var scenario08 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "ク☆scenario",
            Texts = new List<string>()
            {
                "ネットのおもちゃを見てみよう。",
                "棒読みの紙芝居を見てる感じで、面白さはないです、ない！",
                "ニコニコ動画の界隈では、これを全編見せられるのが拷問になるらしいよ、ひえ～っｗ",
                "くれ子ﾁｬﾝもネットのおもちゃにならないようにしないとね……",
                "おぢさんも親衛隊として気を引き締めるのであった(`・ω・́)ゝﾋﾞｼｯ",
                "――――クッキー☆動画を楽しんだ。",
                "今日もいい天気☆を手に入れた"
            }
        };
        var scenario09 = new Scenario()   //varはintとかのなんにでもなる、右辺によって変化する
        {
            ScenarioID = "加藤純一scenario",
            Texts = new List<string>()
            {
                "ニコニコ配信者界の王とも言われる加藤純一を見てみよう。",
                "加藤純一最強！",
                "加藤純一最強！加藤純一最強！",
                "加藤純一最強！加藤純一最強！加藤純一最強！",
                "何処の配信を見てもこんな感じのコメントがたまにあったから、気になっては居たんだよネ……",
                "まぁ、おぢさん的にはくれ子ﾁｬﾝが最強なんだけどｗ",
                "――――加藤純一の配信を楽しんだ。",
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

