using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManeger : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator menuupdate;
    void Start()
    {
        menuupdate = itemupdate();
    }

    // Update is called once per frame
    void Update()
    {
        //menuupdate;
    }
    IEnumerator itemupdate()
    {
        yield return null;
    }

}