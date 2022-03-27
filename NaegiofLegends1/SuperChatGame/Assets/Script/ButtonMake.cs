using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ButtonMake : MonoBehaviour
{
    public GameObject parent;
    public KoubunManager koubunManager;
    public Text superChatText;

    [SerializeField]
    string[] koubunTest = new string[3];

    public string naiyou;

    List<GameObject> buttonsLists = new List<GameObject>();

    void Start()
    {
        parent = GameObject.Find("Text");
        superChatText = parent.gameObject.GetComponent<Text>();
        koubunManager = gameObject.GetComponent<KoubunManager>();
        GameObject button = (GameObject)Resources.Load("Button");
        ButtonMaking(button);
    }

    void AddTag(string tagname)
    {
        UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
        if ((asset != null) && (asset.Length > 0))
        {
            SerializedObject so = new SerializedObject(asset[0]);
            SerializedProperty tags = so.FindProperty("tags");

            for (int i = 0; i < tags.arraySize; ++i)
            {
                if (tags.GetArrayElementAtIndex(i).stringValue == tagname)
                {
                    return;
                }
            }

            int index = tags.arraySize;
            tags.InsertArrayElementAtIndex(index);
            tags.GetArrayElementAtIndex(index).stringValue = tagname;
            so.ApplyModifiedProperties();
            so.Update();
        }
    }

    public void ButtonMaking(GameObject button)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject buttons = (GameObject)Instantiate(button, new Vector3(385, 120 - (i * 35), 0), Quaternion.identity);
            Button buttonNaiyou = buttons.gameObject.GetComponent<Button>();
            buttons.transform.SetParent(this.parent.transform, false);
            Text text = buttons.transform.Find("Text").gameObject.GetComponent<Text>();
            AddTag(i.ToString());
            buttons.tag = i.ToString();
            text.text = koubunManager.koubunArrays[i].name; //作ったボタンの名前を変えている
            buttonsLists.Add(buttons);
        }
    }

    public void DestroyButton()
    {
        for(int i = 0; i < buttonsLists.Count; i++)
        {
            Destroy(buttonsLists[i]);
        }
    }
}
