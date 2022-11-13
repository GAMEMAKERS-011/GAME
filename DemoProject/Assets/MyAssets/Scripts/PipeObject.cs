using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeObject : MonoBehaviour
{
    public GameObject character;
    public GameObject ob;
    bool hasShown=false;

    void Start()
    {
         ob.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 5)
        {
                if(hasShown==false)
                {
                    ob.SetActive(true);
                    hasShown=true;
                }
        }
    }
}
