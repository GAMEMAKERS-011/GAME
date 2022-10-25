using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pigeon_control : MonoBehaviour
{
    public float speed;
    public bool inActive;
    private Animator anim;
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    private bool isGround;//脚下有没有站任何物体
    private float dire;//当前方向
    private float dir;//键盘要求行进方向
    private bool iffly;
    private bool flying;//是否左右飞行
    private bool flyup;
    private bool flydown;
    // Start is called before the first frame update
    void Start()
    {
        dire = 1;//初始化时候向右为正方向
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        inActive = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (isGround)
        {
            anim.SetFloat("flying", 0);
            iffly = false;

        }
        else
        {
            anim.SetFloat("flying", 1);
            iffly = true;
        }
        if (!inActive)
        {
            flyup = false; flydown = false; flying = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("fly up");
                flyup = true; flydown = false;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Debug.Log("fly up end");
                flyup = false;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("fly down");

                flydown = true; flyup = false;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Debug.Log("fly down");
                flydown = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                Debug.Log("Fly Left");
                flying = true;
                dir = -1;

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                Debug.Log("Fly Right");
                flying = true;
                dir = 1;

            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Debug.Log("fly Left end");
                flying = false;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Debug.Log("fly Right end");
                flying = false;
            }
            fly();
        }
    }
    void fly()
    {
        float vecX = rig.velocity.x;
        float vecY = rig.velocity.y;
        if (flying)
        {
            if (dire * dir < 0)
            {
                dire = -dire;
                Vector3 cur = transform.localScale;
                transform.localScale = new Vector3(-cur[0], cur[1], cur[2]);
            }
            if (flyup)
            {
                vecY = speed;

            }

            rig.velocity = new Vector2(dire * speed, vecY);

        }
        if (!flying)
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
        }
        if (flyup && !flying)
        {
            Debug.Log("fly r/l end");
            rig.velocity = new Vector2(rig.velocity.x, speed);

        }



    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = false;
        }
    }

}
