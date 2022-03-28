using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Responses
{
    public string response;
    public int apperPoint;
    public int downerPoint;
}

public class ResponseManager : MonoBehaviour
{
    public Text responseText;

    [SerializeField]
    public List<Responses> responseList = new List<Responses>();
    [SerializeField]
    public List<string> responseTextList = new List<string>();
    [SerializeField]
    public List<int> needPoint = new List<int>();


    private void Start()
    {
        responseText = GameObject.Find("CommentText").GetComponent<Text>();
        responseTextList.Add("あ、スパチャありがとう！");
        responseTextList.Add("スパチャありがとう！");
        responseTextList.Add("え、なにこれｗｗｗ");
        responseTextList.Add("うわすっごいスパチャ、ありがとう！");
        responseTextList.Add("えぇ……（ドン引き）");
        responseTextList.Add("キモスパチャ……");
        needPoint.Add(0);
        needPoint.Add(6);
        needPoint.Add(12);
        needPoint.Add(18);
        needPoint.Add(24);
        needPoint.Add(30);
        needPoint.Add(36);
        for (int i = 0; i < 6; i++)
        {
            responseList.Add(new Responses()
            {
                response = responseTextList[i],
                downerPoint = needPoint[i],
                apperPoint = needPoint[i+1]
            }) ;
        }
    }

    public void Response(int point)
    {
        for(int i = 0; i < responseList.Count; i++)
        {
            if(responseList[i].downerPoint <= point && responseList[i].apperPoint >= point)
            {
                responseText.text = responseList[i].response;
            }
        }
    }




}
