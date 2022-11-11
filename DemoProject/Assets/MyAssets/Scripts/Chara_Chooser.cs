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
    public GameObject girl;
    public GameObject cat;
    private string animalTag;
    private string personTag;

    private int curChar;
    // Start is called before the first frame update
    void Start()
    {
        curChar = 1; //1 person,-1 animal
        animalTag = "null";
        personTag = "girl";
        girl.GetComponent<Character_controller>().inActive = true;
        cat.GetComponent<Cat_controller>().inActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            curChar = curChar * (-1); SwitchPic();
        }
        //人物可动性控制
        if (curChar == 1)
        {
            girl.GetComponent<Character_controller>().inActive = true;
<<<<<<< HEAD
            cat.GetComponent<Cat_controller>().inActive = false;
=======
            cat.GetComponent<Cat_controller>().inActive = false;//todo:
>>>>>>> 1c052d78760b8612883a8a90cc6a065014b8f943
        }
        else
        {
            if (animalTag == "cat")
            {
                girl.GetComponent<Character_controller>().inActive = false;
                cat.GetComponent<Cat_controller>().inActive = true;
            }
        }
    }
    void SwitchPic()
    {
        if (curChar == 1)
        {
            if (personTag != null)
            {
                BigImg.sprite = Person;
                SmallImg.sprite = Animal;

            }
        }
        else
        {
            if (animalTag != null)
            {
                BigImg.sprite = Animal;
                SmallImg.sprite = Person;
            }
        }
    }
    public void SetAnimal(Sprite animal, string tag)
    {
        Animal = animal;
        animalTag = tag;

    }
    public string GetSelected()
    {
        if (curChar == 1)
        {
            return personTag;
        }
        else
        {
            return animalTag;
        }
    }
    public void SetPerson(Sprite person, string tag)
    {
        Person = person;
        personTag = tag;
    }
}
