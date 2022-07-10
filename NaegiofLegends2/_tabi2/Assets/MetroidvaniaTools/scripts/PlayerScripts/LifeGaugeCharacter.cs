using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGaugeCharacter : MonoBehaviour
{
    //　HP
    [SerializeField]
    private int hp;
    //　LifeGaugeスクリプト
    [SerializeField]
    private LifeGauge lifeGauge;
    private LifeGaugeCharacter lifeGaugeCharacter;

    // Start is called before the first frame update
    void Start()
    {
        //　体力の初期化
        hp = 10;
        //　体力ゲージに反映
        var panels = GameObject.Find("Panel");
        lifeGauge = panels.GetComponent<LifeGauge>();
        lifeGauge.SetLifeGauge(hp);
        lifeGaugeCharacter = this.GetComponent<LifeGaugeCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            Debug.Log("ダメージ");
            lifeGaugeCharacter.Damage(1);
        }
    }

    //　ダメージ処理メソッド（全削除＆HP分作成）
    public void Damage(int damage)
    {
        hp -= damage;
        //　0より下の数値にならないようにする
        hp = Mathf.Max(0, hp);

        if (hp >= 0)
        {
            lifeGauge.SetLifeGauge(hp);
        }
    }
}
