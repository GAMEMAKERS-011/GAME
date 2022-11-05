using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject chara_chooser;     // link to item_bar
    public GameObject cinemachine;
    public GameObject cat;  //link to possible candidates
    public GameObject girl;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("shift"))
        {
            //press shift button to change character camera
            Debug.Log("shift pressed!");
            string tag = chara_chooser.GetComponent<Chara_Chooser>().GetSelected(); //get tag from itembar
            CinemachineVirtualCamera cm = cinemachine.GetComponent<CinemachineVirtualCamera>();
            if(tag == "cat")
            {
                cm.Follow = cat.GetComponent<Transform>();
            }
            if(tag == "girl")
            {
                cm.Follow = girl.GetComponent<Transform>();
            }

            Debug.Log("Finish Camera Transition!");
        }
    }
}
