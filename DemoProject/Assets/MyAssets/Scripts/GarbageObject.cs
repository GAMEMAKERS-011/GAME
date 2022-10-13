using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarbageObject : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject[] infoWindows;   // link the pop-up window
    public GameObject[] objects;
    bool hasShowWindow=false;
    int windowindex=-1;
    bool[] hasShown={false,false,false};

    void Start()
    {
          foreach(var window in infoWindows)
          {
               window.SetActive(false);
          }
          foreach(var obj in objects)
          {
               //obj.GetComponent<Renderer>().enabled = false;
               obj.SetActive(false);
          }
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 5)
        {
            if(Input.GetButtonDown("InteractButton"))
            {
                Debug.Log("Close distance and button pressed!");
                if(hasShowWindow==false)
                {
                    windowindex = Random.Range(0, infoWindows.Length); 
                    infoWindows[windowindex].SetActive(true);
                    if(hasShown[windowindex]==false)
                    {
                        //objects[windowindex].GetComponent<Renderer>().enabled = true;
                        objects[windowindex].SetActive(true);
                        hasShown[windowindex]=true;
                    }
                    hasShowWindow=true;
                }
                else
                {
                    infoWindows[windowindex].SetActive(false);
                    //objects[windowindex].GetComponent<Renderer>().enabled = false;
                    hasShowWindow=false;
                }
            }
        }
    }
}
