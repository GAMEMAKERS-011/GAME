using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeObject : MonoBehaviour
{
    public GameObject character;
    public GameObject ob;
    public GameObject cat;
    bool hasShown=false;

    void Start()
    {
         ob.SetActive(false);
    }
    void Awake(){
        cat = GameObject.Find("cat");
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 5
        || Vector3.Distance(cat.transform.position, transform.position) < 5)
        {
                if(hasShown==false)
                {
                    ob.SetActive(true);
                    hasShown=true;
                }
        }
        
    }
}
