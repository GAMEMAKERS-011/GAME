using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandObject : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject key;
    public GameObject hand;
    public GameObject girl;
    public GameObject cat;
    
    bool hasShown = false;

    void Start()
    {
        key.SetActive(false);
    }

    void Awake(){
        girl = GameObject.Find("girl");
    }
    void Update()
    {
        //cat attacks the hand
        if (Vector3.Distance(character.transform.position, transform.position) < 2 
            && character.GetComponent<Cat_controller>().inActive)
        {
            // need to change input manager in player setting
            if(Input.GetButtonDown("InteractButton") )
            {
                if(hasShown==false)
                {
                    key.SetActive(true);
                    hand.SetActive(false);
                    hasShown = true;
                    
                }
            }
        }
        //hand get the girl and girl dies
        if(Vector3.Distance(girl.transform.position, transform.position) < 1 )
        {
            // Debug.Log("die");
            Invoke("die",1);
        }
    }

    void die(){
        GameObject.Find("deadWindow").SendMessage("die");
    }
}
