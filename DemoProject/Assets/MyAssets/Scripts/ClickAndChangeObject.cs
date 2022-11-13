using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickAndChangeObject : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public SpriteRenderer sr;//组件
    public Sprite[] pic;//图片
    public GameObject itemBar;
    bool hasOpened = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = pic[0];
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 10)
        {
            // need to change input manager in player setting
            if(Input.GetButtonDown("InteractButton"))
            {
                Debug.Log("Close distance and button pressed!");
                if(hasOpened == false)
                {
                    string tag = "keyA";
                    bool s = itemBar.GetComponent<itemChoser>().Query(tag);
                    if(s==true)
                    {
                        sr.sprite = pic[1];
                        hasOpened = true;
                    }
                }
            }
        }
    }
}
