using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class manager : MonoBehaviour
{
    public GameObject girl;
    public GameObject climber;
    public GameObject grand;
    public GameObject slider;
    public GameObject cat;
    private GameObject deadImage;
    public GameObject cinemachine;
    public int shirtCount;
    private CinemachineVirtualCamera cm;
    public GameObject mother;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject leader;
    private float count;//教主在外面站十秒回去
    private bool changeRight;//是否成功调换了酒杯
    // Start is called before the first frame update
    void Start()
    {
        deadImage = GameObject.Find("deadImage");
        shirtCount = 0;
        cm = cinemachine.GetComponent<CinemachineVirtualCamera>();
        changeRight = false;

    }
    public void SetChangeRight()
    {
        changeRight = true;
    }
    public bool GetChangeRight()
    {
        return changeRight;
    }
    void SliderBegin()
    {

        girl.GetComponent<Character_controller>().inActive = false;//先让人物不动，人物完成当前动作的停止。
        girl.SetActive(false);//再设置该人物object的属性
        slider.SetActive(true);
    }
    public void changedSucceed()//女孩交换了酒杯
    {
        girl.SetActive(false);
        cm.Follow = leader.GetComponent<Transform>();
        leader.GetComponent<Animation>().Play("leader_pan_out");
        //进入最后界面，展示母亲生死---------Todo

    }
    public void LeaderHigh()
    {
        leader.GetComponent<Animation>().Play("leader_high");
    }
    public void leaderOut()//十字架倒下之后促使Leader出来
    {
 
        cat.GetComponent<Cat_controller>().lActive = false;
        leader.GetComponent<Animation>().Play("leader_out");//出来并且击打猫猫

    }
    public void catLeave()
    {
        cat.GetComponent<Animation>().Play("cat_leave_house");
    }

    public void SliderEnd()
    {
        slider.SetActive(false);
        girl.SetActive(true);
        Vector2 newP = new Vector2();
        newP.x = 49.4f; newP.y = 10f;
        girl.GetComponent<Transform>().position = newP;

    }
    public void GrandmaEnd()
    {
        grand.SetActive(false);
        deadImage.SetActive(true);
        //女孩被拖走后的界面展示
    }
    void hasLadder()
    {
        climber.SetActive(true);
        girl.GetComponent<Character_controller>().inActive = false;//先让人物不动，人物完成当前动作的停止。
        girl.SetActive(false);//再设置该人物object的属性
        climber.GetComponent<Climber_control>().climbLadder = true;
        Vector2 newP = girl.GetComponent<Transform>().position;
        newP.x = newP.x + 0.12f; newP.y = newP.y + 2.2f;
        climber.GetComponent<Transform>().position = newP;
        cm.Follow = climber.GetComponent<Transform>();
    }
    public void climbEnd()
    {
        climber.SetActive(false);
        girl.SetActive(true);
        girl.GetComponent<Character_controller>().inActive = true;
        girl.GetComponent<Character_controller>().climbEnd = true;
        Vector2 newP = climber.GetComponent<Transform>().position;
        newP.x = 30.7f; newP.y = 15.1f;
        girl.GetComponent<Transform>().position = newP;
        cm.Follow = girl.GetComponent<Transform>();
    }
    public void climbToGirl(int dir)
    {
        climber.SetActive(false);
        climber.GetComponent<Climber_control>().climbLadder = false;
        girl.SetActive(true);
        girl.GetComponent<Character_controller>().inActive = true;
        Vector2 newP = climber.GetComponent<Transform>().position;
        newP.x = newP.x - 0.12f;
        girl.GetComponent<Transform>().position = newP;
        cm.Follow = girl.GetComponent<Transform>();
        girl.GetComponent<Character_controller>().SetDir(dir);

    }

    void girlToClimb()
    {
        girl.SetActive(false);
        climber.SetActive(true);
        Vector2 newP = girl.GetComponent<Transform>().position;
        newP.x = newP.x + 0.12f; newP.y = newP.y + 2;
        climber.GetComponent<Transform>().position = newP;
        cm.Follow = climber.GetComponent<Transform>();


    }
    void ladderOpen()//梯子已经打开
    {
        girl.GetComponent<Character_controller>().ladderCanUse = true;
    }
}
