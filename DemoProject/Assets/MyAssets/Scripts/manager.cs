using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject girl;
    public GameObject climber;

   
    // Start is called before the first frame update
    void Start()
    { 

    }
    void hasLadder()
    {
        climber.SetActive(true);
        girl.GetComponent<Character_controller>().inActive = false;//先让人物不动，人物完成当前动作的停止。
        girl.SetActive(false);//再设置该人物object的属性

    }
    public void climbEnd()
    {
        climber.SetActive(false);
        girl.SetActive(true);
        girl.GetComponent<Character_controller>().inActive = true;
        girl.GetComponent<Character_controller>().climbEnd = true;
        Vector2 newP = climber.GetComponent<Transform>().position;
        newP.x = newP.x - 6;newP.y = newP.y + 2;
        girl.GetComponent<Transform>().position = newP;
    }
}
