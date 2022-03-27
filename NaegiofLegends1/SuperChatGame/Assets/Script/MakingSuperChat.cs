using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MakingSuperChat : MonoBehaviour
{
    GameObject koubunM;
    KoubunManager koubunManager;
    GameObject text;
    Text superChatText;

    public int superChatNum = 0;
    [SerializeField]
    public int superChatLimit = 3;

    private void Start()
    {
        koubunM = GameObject.Find("KoubunManager");
        koubunManager = koubunM.GetComponent<KoubunManager>();
        text = transform.parent.gameObject;
        superChatText = text.gameObject.GetComponent<Text>();
    }

    public void SuperChat()
    {
        string tagnum = this.tag;
        int num = int.Parse(tagnum);
        superChatNum++;
        if (superChatNum < superChatLimit)
        {
            superChatText.text = superChatText.text + koubunManager.koubunArrays[num].naiyou;
        }
    }

    public void ResetSuperChat()
    {
        superChatNum = 0;
        superChatText.text = "";
    }

}
