using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicInteractiveObject : MonoBehaviour
{
    //public string infoMsg = ""; // the variable that holds the object information to display in the pop-up window
    public GameObject character;    // link an instance of the character to calculate the distance
    //public GameObject infoWindow;   // link the pop-up window
    public GameObject animi;
    bool hasPlayed = false;
    //bool hasShownWindow = false;    // press x key again to disable the pop-up window

    void Start()
    {
        //infoWindow.SetActive(false);
        //animi.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        Animator ani = gameObject.GetComponent<Animator>();
        if (Vector3.Distance(character.transform.position, transform.position) < 5)
        {
            // need to change input manager in player setting
            if(Input.GetButtonDown("InteractButton"))
            {
                Debug.Log("Close distance and button pressed!");
                if(hasPlayed==false)
                {
                    animi.GetComponent<Renderer>().enabled = true;
                    ani.Play("animation",0,0);
                    hasPlayed = true;
                    StartCoroutine(enumerator());
                }
            }
        }
    }
   IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.3f);
        Animator ani = gameObject.GetComponent<Animator>();
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("animation"))
        {
            Debug.Log("播放clear");
            while (ani.GetCurrentAnimatorStateInfo(0).normalizedTime<1.0f)
            {
                yield return null;
            }
            Debug.Log("播放完毕");
            animi.GetComponent<Renderer>().enabled = false;
        }
    }
}
