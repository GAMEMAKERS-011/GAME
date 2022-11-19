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
    private bool nearLadder;
    bool hasOpened = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = pic[0];
        nearLadder = false;
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 10||nearLadder)
        {
            // need to change input manager in player setting
            if(Input.GetButtonDown("InteractButton"))
            {
                Debug.Log("Close distance and button pressed!");
                if(hasOpened == false)
                {
                    SendMessageUpwards("ladderOpen", SendMessageOptions.DontRequireReceiver);
                    sr.sprite = pic[1];
                        hasOpened = true;
                  
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ladder")
        {
            nearLadder = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "ladder")
        {
            nearLadder = false;
        }
    }
}
