using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_controller : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    private float dire;//当前方向
    private float dir;//键盘要求行进方向
    private Animator anim;
    private Rigidbody2D rig;
    private bool walk;
    private bool jump;
    private bool down;
    private bool isGround;//1:可以跳跃，2：不可以  
                          // public GameObject itemList;
    public GameObject character;    //link to the person character
    public GameObject itemBar;      //link to the item bar
    public GameObject charaChooser;  //link to the chara chooser

    void Start()
    {
        dire = 1;//初始化时候向右为正方向
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        //anim.SetBool("test", false);
        jump = false;
        walk = false;

    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                Debug.Log("jump pressed or up");
                jump = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump press end");
            jump = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down Ward");
            //  Sprite girl=Resources.Load("girl", typeof(Sprite)) as Sprite;
            // itemList.GetComponent<itemChoser>().AddNew(girl, 2);
            down = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("Down Ward end");
            down = false;
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
        //测试动画效果的if，后期会删掉
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("cat eat");
            anim.SetFloat("eat", 1);
          
        }
        if (Vector3.Distance(character.transform.position, transform.position) < 100)
        {
            //人物走进
            if(Input.GetButtonDown("InteractButton"))
            {
                //按下x
                if(itemBar.GetComponent<itemChoser>().Query("milk"))
                {
                    //如果物品栏中有牛奶
                    //to-do : 调用猫吃东西的动画
                 //   anim.SetFloat("eat", 1);
                  //  itemBar.GetComponent<itemChoser>().DeleteItem("milk");
                    //charaChooser.GetComponent<Chara_Chooser>().SetAnimal(, "milk");   (差图片)

                }

            }
        }
        SwitchAnim();
        walker();
        jumper();
    }
    void eatend()
    {
        Debug.Log("eat end");
        anim.SetFloat("eat", 0); //anim.SetFloat("idle", 1);
    }
    void SwitchAnim()
    {
        if(anim.GetFloat("idle")==1)
        {
            anim.SetFloat("idle", 0);
        }
        if (anim.GetFloat("fall") == 1 && isGround)
        {
            anim.SetFloat("idle", 1);
            anim.SetFloat("fall", 0);

        }
        if (anim.GetFloat("jump") == 1)
        {
            if (rig.velocity.y < 0)//开始落地
            {
                anim.SetFloat("jump", 0);
                anim.SetFloat("fall", 1);
            }
            jump = false;
        }
        if (!walk)
        {
            anim.SetFloat("walk", 0);
        }

    }

    void walker()
    {
        if (walk)
        {
            if (isGround)
            {
                /* float distance = speed * Time.deltaTime * dir;
                 if (distance * dire < 0)
                 {
                     transform.localScale = new Vector3(-dire, 1, 1);
                     dire = -dire;
                 }
                 anim.SetFloat("walk", 1);
                 transform.Translate(Vector3.right * distance);*/

                if (dir * dire < 0)
                {
                    dire = -dire;
                    transform.localScale = new Vector3(dire, 1, 1);
                }

                rig.velocity = new Vector2(dire * speed, rig.velocity.y);
                anim.SetFloat("walk", 1);

            }
            else
            {
                if (jump)
                {
                    if (dir * dire < 0)
                    {
                        dire = -dire;
                        transform.localScale = new Vector3(dire, 1, 1);
                    }
                    rig.velocity = new Vector2(dire * speed, rig.velocity.y);
                }
            }
        }
    }
    void jumper()
    {
        if (jump)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
            anim.SetFloat("jump", 1);

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
