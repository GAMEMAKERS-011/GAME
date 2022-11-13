using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandObject : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject key;
    public GameObject hand;
    bool hasShown = false;

    void Start()
    {
        key.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 5)
        {
            // need to change input manager in player setting
            if(Input.GetButtonDown("InteractButton"))
            {
                if(hasShown==false)
                {
                    key.SetActive(true);
                    hand.SetActive(false);
                    hasShown = true;
                }
            }
        }
    }
}
