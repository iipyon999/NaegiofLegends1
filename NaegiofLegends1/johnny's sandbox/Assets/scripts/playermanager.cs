using UnityEngine;

public class playermanager : MonoBehaviour
{
    [SerializeField] LayerMask blockLayer;

    public enum DIRECTION_TYPE 
    {
        STOP,
        RIGHT,
        LEFT,
    }

    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;

    Rigidbody2D rigitbody2d;
    float speed;

    float jumppower = 400;

    private void Start()
    {
        rigitbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x == 0) 
        {
            //　止まっている
            direction = DIRECTION_TYPE.STOP;
        }
        else if (x > 0) 
        {
            //　右へ
            direction = DIRECTION_TYPE.RIGHT;
        }
        else if (x < 0)
        {
            //　左へ
            direction = DIRECTION_TYPE.LEFT;
        }

        // スペースが押されたらJUMPさせる
        if (Input.GetKeyDown("space")) 
        {
            Jump();
        }


    }

    private void FixedUpdate()
    {
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;
            case DIRECTION_TYPE.RIGHT:
                speed = 3;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case DIRECTION_TYPE.LEFT:
                speed = -3;
                transform.localScale = new Vector3(-1, 1, 1);
                break;

        }

        rigitbody2d.velocity = new Vector2(speed, rigitbody2d.velocity.y);

    }

    void Jump()
    {
        //上に力を加える
        rigitbody2d.AddForce(Vector2.up * jumppower);
        Debug.Log("Jump");
    }

}
