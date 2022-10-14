using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToObjectBucket : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject obj;
    bool hasAdd=false;

    void Start()
    {
    }

    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 1)
        {
            if(Input.GetButtonDown("InteractButton"))
            {
                if(hasAdd==false)
                {
                     hasAdd=true;
                     Debug.Log("picked");
                     obj.GetComponent<Renderer>().enabled = false;
                     //加入物品栏
                }
            }
        }
    }
}
