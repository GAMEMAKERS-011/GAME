using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupsObject : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject obj;
    public GameObject words;
    public GameObject[] cups;
    public GameObject[] half;
    public GameObject[] full;
    int now=0;
    int[] choose = {-1, -1};

    void Start()
    {
          foreach(var i in half)
          {
               i.GetComponent<Renderer>().enabled = false;
          }
          foreach(var j in full)
          {
               j.GetComponent<Renderer>().enabled = false;
          }
          half[now].GetComponent<Renderer>().enabled = true;
          words.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 1000)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) && now>0)
            {
                if(choose[0]!=now && choose[1]!=now)
                {
                    half[now].GetComponent<Renderer>().enabled = false;
                }
                now=now-1;
                if(choose[0]!=now && choose[1]!=now)
                {
                    half[now].GetComponent<Renderer>().enabled = true;
                }
            }
            if(Input.GetKeyDown(KeyCode.RightArrow) && now<4)
            {
                if(choose[0]!=now && choose[1]!=now)
                {
                    half[now].GetComponent<Renderer>().enabled = false;
                }
                now=now+1;
                if(choose[0]!=now && choose[1]!=now)
                {
                    half[now].GetComponent<Renderer>().enabled = true;
                }
            }
            if(Input.GetButtonDown("SelectButton"))
            {
                Debug.Log("Close distance and button pressed!");
                if(choose[0]==-1 && choose[1]==-1)
                {
                    choose[0]=now;
                    half[now].GetComponent<Renderer>().enabled = false;
                    full[now].GetComponent<Renderer>().enabled = true;
                }
                else if(choose[0]==now && choose[1]==-1)
                {
                    choose[0]=-1;
                    half[now].GetComponent<Renderer>().enabled = true;
                    full[now].GetComponent<Renderer>().enabled = false;
                }
                else if(choose[0]==-1 && choose[1]==now)
                {
                    choose[1]=-1;
                    half[now].GetComponent<Renderer>().enabled = true;
                    full[now].GetComponent<Renderer>().enabled = false;
                }
                else if(choose[0]!=-1 && choose[1]==-1)
                {
                    obj.SetActive(false);
                    words.SetActive(true);
                    words.GetComponent<Words>().StartPlay(1);
                }
                else if(choose[0]==-1 && choose[1]!= -1)
                {
                    obj.SetActive(false);
                    words.SetActive(true);
                    words.GetComponent<Words>().StartPlay(1);
                }
            }
        }
    }
}
