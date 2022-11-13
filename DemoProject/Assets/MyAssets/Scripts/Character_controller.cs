using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_controller : MonoBehaviour
{
    public int speed;
    public float maxSpeed;
    public float acceleration;
    public int jumpForce;
    public bool inActive;
    public GameObject climber;
    public GameObject itemBar;
    public bool climbEnd;

    private float dire;//当前方向
    private float dir;//键盘要求行进方向
    private Animator anim;
    private Rigidbody2D rig;
    private BoxCollider2D coll;

    //控制人物行走跳跃
    private bool walk;
    private bool jump;

    private bool isGround;//1:可以跳跃，2：不可以  
    private bool hasLadder;//判断是否碰到梯子
    private bool ladderEnd;//是否第一次远离梯子了
    private bool ifclimb;//这个梯子是否爬过了
    private bool nearRope;

    // public GameObject itemList;
    void Start()
    {
        dire = 1;//初始化时候向右为正方向\
      
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        

        jump = false;
        walk = false;
        inActive = true;
        hasLadder = false;//初始化时并不在梯子上
        climbEnd = false;
        climber.SetActive(false);
        ladderEnd = true;
        nearRope = false;

        //set can be collide
        rig.simulated = true;
        rig.freezeRotation = true;
        coll.isTrigger = false;
    }
    void Update()
    {
        if (!inActive)
        {
            jump = false; walk = false;

            if (anim.GetFloat("walk") > 0.1)
            {
                anim.SetFloat("walk", 0); anim.SetFloat("idle", 1);
                rig.velocity = new Vector2(0, 0);
            }
            SwitchAnim();

        }
        else
        {
            rig.simulated = true;
            coll.isTrigger = false;
            if(nearRope)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("press x,use rope");
                    //按下x
                    if (itemBar.GetComponent<itemChoser>().Query("hanger"))
                    {
                       
                        itemBar.GetComponent<itemChoser>().DeleteItem("hanger");
                        SendMessageUpwards("SliderBegin", SendMessageOptions.DontRequireReceiver);


                    }

                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("jump pressed or up");
                jump = true;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("jump up");
                jump = false;
            }


            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                Debug.Log("Walk Left");
                walk = true;
                dir = -1;

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                Debug.Log("Walk Right");
                walk = true;
                dir = 1;

            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Debug.Log("Walk Left end");
                walk = false;

            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Debug.Log("Walk Right end");
                walk = false;
            }

            //    walker();
            //  jumper();
            SwitchAnim();
        }
    }

    void FixedUpdate()
    {
       
        UpdateVelocity();
        UpdateJump();
        SwitchAnim();

    }
    void UpdateVelocity()
    {
        Vector3 cur = transform.localScale;//获取当前localSacle的参数，允许人物大小随意调节
        Vector2 curVelocity = rig.velocity; //当前运动速度
        if(dir*dire<0)//行走方向与原方向不符合
        {
            transform.localScale = new Vector3(-cur[0], cur[1], cur[2]);
            dire = dir;
        }

        if (walk)
        {
            curVelocity.x += dir * acceleration * Time.fixedDeltaTime;
            curVelocity.x = Mathf.Clamp(curVelocity.x, -maxSpeed, maxSpeed);//防止超出maxSpeed限制
            rig.velocity = curVelocity; 
            float animSpeed = Mathf.Abs(curVelocity.x) / maxSpeed;
            anim.SetFloat("walk", animSpeed);//设置动画速度
        }
    


    }
    void UpdateJump()
    {
        if(isGround&&jump)//a jump begin
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;//一次jump仅改变一次jumpForce
            anim.SetFloat("idle", 0);
            anim.SetFloat("fall", 0);
            anim.SetFloat("jump", 1);
            
        }
    }
    void SwitchAnim()
    {
        if (anim.GetFloat("jump")==1)
        {
            if (rig.velocity.y < 0)//开始落地
            {
                anim.SetFloat("jump", 0);
                anim.SetFloat("fall", 1);
            }
            //jump = false;
        }
        /*      if(walk&&!anim.GetBool("jump"))
              {
                  anim.SetFloat("walk", 1);
              }*/
        if (rig.velocity.x == 0)
        {
            anim.SetFloat("walk", 0);

        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = true;
            ifclimb = true;//碰到地面时，默认上次爬梯子结束
            ladderEnd = true;
            if (anim.GetFloat("fall")==1 && isGround)
            {
                anim.SetFloat("idle", 1);
                anim.SetFloat("fall", 0);

            }
            if (!inActive)
            {
                rig.simulated = false;
                coll.isTrigger = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ladder" && ladderEnd)
        {
            Debug.Log("find ladder");
            hasLadder = true;
            inActive = false;
            ladderEnd = false;

            jump = false; walk = false;
            anim.SetFloat("walk", 0);
            anim.SetFloat("idle", 1);
            rig.velocity = new Vector2(0, 0);


            SendMessageUpwards("hasLadder", SendMessageOptions.DontRequireReceiver);
            SwitchAnim();
            Debug.Log("get ladder");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "rope")
        {
            nearRope = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.transform.tag == "rope")
        {
            nearRope = false;
        }


    }






}
