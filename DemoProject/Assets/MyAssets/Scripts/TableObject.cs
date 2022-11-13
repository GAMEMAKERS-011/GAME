using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableObject : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject infoWindow;   // link the pop-up window
    public GameObject words;
    bool hasShownWindow = false;    // press x key again to disable the pop-up window

    void Start()
    {
        infoWindow.SetActive(false);
        words.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 5)
        {
            // need to change input manager in player setting
            if(Input.GetButtonDown("InteractButton"))
            {
                Debug.Log("Close distance and button pressed!");
                if(hasShownWindow==false)
                {
                    infoWindow.SetActive(true);
                    hasShownWindow = true;
                }          
            }
        }
    }


}
