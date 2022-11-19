using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject girl;
    public GameObject climber;
    public GameObject grand;
    public GameObject slider;
    private GameObject deadImage;
    public int shirtCount;

    // Start is called before the first frame update
    void Start()
    {
        deadImage = GameObject.Find("deadImage");
        shirtCount = 0;
    }
    void SliderBegin()
    {

        girl.GetComponent<Character_controller>().inActive = false;//先让人物不动，人物完成当前动作的停止。
        girl.SetActive(false);//再设置该人物object的属性
        slider.SetActive(true);
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
        newP.x = newP.x + 0.12f;newP.y = newP.y + 2.2f;
        climber.GetComponent<Transform>().position = newP;
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
        girl.GetComponent<Character_controller>().SetDir(dir);
    }

    void girlToClimb()
    {
        girl.SetActive(false);
        climber.SetActive(true);
        Vector2 newP = girl.GetComponent<Transform>().position;
        newP.x = newP.x + 0.12f; newP.y = newP.y + 2;
        climber.GetComponent<Transform>().position = newP;



    }
    void ladderOpen()//梯子已经打开
    {
        girl.GetComponent<Character_controller>().ladderCanUse = true;
    }
}
