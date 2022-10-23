using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowObject : MonoBehaviour
{
    //public string infoMsg = ""; // the variable that holds the object information to display in the pop-up window
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject infoWindow;   // link the pop-up window
    bool hasShownWindow = false;    // press x key again to disable the pop-up window

    void Start()
    {
        infoWindow.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 50)
        {
            // need to change input manager in player setting
            if(Input.GetButtonDown("InteractButton"))
            {
                Debug.Log("Close distance and button pressed!");
                if(hasShownWindow)
                {
                    infoWindow.SetActive(false);
                    //infoWindow.transform.Find("infoStr").gameObject.SetActive(false);
                    hasShownWindow = false;
                }
                else
                {
                    infoWindow.SetActive(true);
                    hasShownWindow = true;
                    //infoWindow.transform.Find("infoStr").gameObject.SetActive(true);
                    //infoWindow.transform.Find("infoStr").gameObject.GetComponent<Text>().text = "����";
                }
                
            }
        }
    }


}
