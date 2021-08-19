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

    CharacterController charactercontroller;
    float speed;
    
    /*
    float jumppower = 400;
    */

    float gravity = -1;

    private void Start()
    {
        charactercontroller = GetComponent<CharacterController>();
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

        /*
        // スペースが押されたらJUMPさせる
        if (IsGround() && Input.GetKeyDown("space")) 
        {
            Jump();
        }
        */

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

        Vector3 move = new Vector3(speed, gravity, 0);
        charactercontroller.Move(move);

    }

    /*void Jump()
    {
        //上に力を加える
        Debug.Log("Jump");
    }
    */

    bool IsGround()
    {
        // 始点と終点を作成
        Vector3 leftStartPoint = transform.position - Vector3.right * 0.2f;
        return true;
    }
}
