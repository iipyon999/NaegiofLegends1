using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move=Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            move.x = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x = moveSpeed;
        }
        transform.Translate(move);
    }
}
