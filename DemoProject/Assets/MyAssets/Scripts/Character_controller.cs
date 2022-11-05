using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_controller : MonoBehaviour
{
    public int speed;
    public int jumpForce;
    public bool inActive;
    public GameObject climber;
    public bool climbEnd;
    private float dire;//��ǰ����
    private float dir;//����Ҫ���н�����
    private Animator anim;
    private Rigidbody2D rig;
    private bool walk;
    private bool jump;
    private bool down;
    private bool isGround;//1:������Ծ��2��������  
    private bool hasLadder;//�ж��Ƿ���������
    private bool ladderEnd;//�Ƿ��һ��Զ��������
    private bool ifclimb;//��������Ƿ�������

    // public GameObject itemList;
    void Start()
    {
        dire = 1;//��ʼ��ʱ������Ϊ������
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        //anim.SetBool("test", false);
        jump = false;
        walk = false;
        inActive = true;
        hasLadder = false;//��ʼ��ʱ������������
        climbEnd = false;
        climber.SetActive(false);
        ladderEnd = true;

    }
    void Update()
    {

        if (!inActive)
        {
            jump = false; walk = false;
            anim.SetFloat("walk", 0);
            anim.SetFloat("idle", 1);
            rig.velocity = new Vector2(0, 0);
            SwitchAnim();
        }
        else
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
            SwitchAnim();
            walker();
            jumper();
        }
    }
    void SwitchAnim()
    {
        if (anim.GetFloat("fall") == 1 && isGround)
        {
            anim.SetFloat("idle", 1);
            anim.SetFloat("fall", 0);

        }
        if (anim.GetFloat("jump") == 1)
        {
            if (rig.velocity.y < 0)//��ʼ���
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

                if (dir * dire < 0)
                {
                    dire = -dire;
                    Vector3 cur = transform.localScale;
                    transform.localScale = new Vector3(-cur[0], cur[1], cur[2]);

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
                        Vector3 cur = transform.localScale;
                        transform.localScale = new Vector3(-cur[0], cur[1], cur[2]);
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
            ifclimb = true;//��������ʱ��Ĭ���ϴ������ӽ���
            ladderEnd = true;
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






}
