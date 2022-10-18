using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chara_Chooser : MonoBehaviour
{
    public Sprite Animal;
    public Sprite Person;
    public Image BigImg;
    public Image SmallImg;
    private int curChar;
    // Start is called before the first frame update
    void Start()
    {
        curChar = 1; //1 person,-1 animal
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            curChar = curChar * (-1);SwitchPic();
        }
        
    }
    void SwitchPic()
    {
        if(curChar==1)
        {
            BigImg.sprite = Animal;
            SmallImg.sprite = Person;
        }else
        {
            BigImg.sprite = Person;
            SmallImg.sprite =Animal;
        }
    }
}
