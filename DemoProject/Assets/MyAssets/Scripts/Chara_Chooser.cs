using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chara_Chooser : MonoBehaviour
{
    public Sprite Animal;
    private string animalTag;
    private string personTag;
    public Sprite Person;
    public Image BigImg;
    public Image SmallImg;
    private int curChar;
    // Start is called before the first frame update
    void Start()
    {
        curChar = 1; //1 person,-1 animal
        animalTag = null;
        personTag = null;
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
            BigImg.sprite = Person;
            SmallImg.sprite =Animal;
           
        }else
        {
             BigImg.sprite = Animal;
            SmallImg.sprite = Person;
        }
    }
    public void SetAnimal(Sprite animal,string tag)
    {
        Animal = animal;
        animalTag = tag;

    }
    public string GetSelected()
    {
        if(curChar==1)
        {
            return personTag;
        }else
        {
            return animalTag;
        }
    }
    public void SetPerson(Sprite person,string tag)
    {
        Person = person;
        personTag = tag;
    }
}
