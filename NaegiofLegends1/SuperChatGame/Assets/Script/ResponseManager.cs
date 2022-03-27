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
    public List<Responses> responses = new List<Responses>();
    [SerializeField]
    public List<string> response = new List<string>();
    [SerializeField]
    public List<int> point = new List<int>();


    private void Start()
    {
        responseText = GameObject.Find("CommentText").GetComponent<Text>();
        response.Add("あ、スパチャありがとう！");
        response.Add("スパチャありがとう！");
        response.Add("え、なにこれｗｗｗ");
        response.Add("うわすっごいスパチャ、ありがとう！");
        response.Add("えぇ……（ドン引き）");
        response.Add("キモスパチャ……");
        point.Add(0);
        point.Add(6);
        point.Add(12);
        point.Add(18);
        point.Add(24);
        point.Add(30);
        point.Add(36);
        for (int i = 0; i < 6; i++)
        {
            responses.Add(new Responses()
            {
                response = response[i],
                downerPoint = point[i],
                apperPoint = point[i+1]
            }) ;
        }
    }

    public void Response(int point)
    {
        for(int i = 0; i < responses.Count; i++)
        {
            if(responses[i].downerPoint <= point && responses[i].apperPoint >= point)
            {
                responseText.text = responses[i].response;
            }
        }
    }




}
