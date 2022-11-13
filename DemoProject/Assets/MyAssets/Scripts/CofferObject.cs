using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CofferObject : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject notebook;   // link the pop-up window
    public GameObject itemBar;
    public GameObject obj;
    public SpriteRenderer sr;//组件
    public Sprite[] pic;//图片
    bool hasOpened = false;
    bool hasShowWindow = false;

    void Start()
    {
        notebook.SetActive(false);
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = pic[0];
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 5)
        {
            // need to change input manager in player setting
            if(Input.GetButtonDown("InteractButton"))
            {
                Debug.Log("Close distance and button pressed!");
                if(hasOpened == false)
                {
                    string tag = "keyB";
                    bool s = itemBar.GetComponent<itemChoser>().Query(tag);
                    if(s==true)
                    {
                        sr.sprite = pic[1];
                        hasOpened = true;
                    }
                }
                else
                {
                    if(hasShowWindow)
                    {
                        notebook.SetActive(false);
                        hasShowWindow = false;
                    }
                    else
                    {
                        notebook.SetActive(true);
                        notebook.GetComponent<Words>().StartPlay(0);
                        hasShowWindow = true;
                    }
                }
            }
        }
    }
}
