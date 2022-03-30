using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjisanActionManager : MonoBehaviour
{
    GameController gameController;

    GameObject OjisanActionMarker;
    GameObject OjisanActionPossible;
    GameObject OjisanActionNotPossible;

    public List<GameObject> OjisanActionMarkerLists = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        OjisanActionMarker = GameObject.Find("OjisanActionMarker");
        OjisanActionPossible = (GameObject)Resources.Load("OjisanActionPossible");
        OjisanActionNotPossible = (GameObject)Resources.Load("OjisanActionNotPossible");
        ActionMarkerSetting();
    }

    void ActionMarkerSetting()
    {
        int canActionNum; //おじさんが後何回行動できるかを取る変数
        canActionNum = gameController.ojisanActionLimit - gameController.ojisanAction;
        for(int i = 0; i < canActionNum ; i++)
        {
            OjisanActionMarkerLists.Add(OjisanActionPossible);
        }
        for(int i = canActionNum; i < gameController.ojisanActionLimit; i++)
        {
            OjisanActionMarkerLists.Add(OjisanActionNotPossible);
        }
        for(int i = 0;i < OjisanActionMarkerLists.Count; i++)
        {
            GameObject OjisanMarker =  (GameObject)Instantiate(OjisanActionMarkerLists[i],new Vector3((i*110),0,0), Quaternion.identity);
            OjisanMarker.transform.SetParent(OjisanActionMarker.transform, false);
        }

    }



}
