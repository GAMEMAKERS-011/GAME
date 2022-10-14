using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CofferObject : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject infoWindow;   // link the pop-up window
    public SpriteRenderer sr;//组件
    public Sprite[] pic;//图片
    bool hasOpened = false;
    bool hasShowWindow = false;

    void Start()
    {
        infoWindow.SetActive(false);
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
                    sr.sprite = pic[1];
                    hasOpened = true;
                }
                else
                {
                    if(hasShowWindow)
                    {
                        infoWindow.SetActive(false);
                        hasShowWindow = false;
                    }
                    else
                    {
                        infoWindow.SetActive(true);
                        hasShowWindow = true;
                    }
                }
            }
        }
    }
}
