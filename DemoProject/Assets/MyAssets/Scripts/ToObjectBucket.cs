using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToObjectBucket : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject obj;
    public GameObject itemBar;  // link to the item bar
    bool hasAdd=false;

    void Start()
    {
    }

    void Update()
    {
        //Debug.Log(Vector3.Distance(character.transform.position, transform.position));
        if (Vector3.Distance(character.transform.position, transform.position) < 100)
        {
            //Debug.Log("test small dist!");
            if(Input.GetButtonDown("InteractButton"))
            {
                if(hasAdd==false)
                {
                    hasAdd=true;
                    Debug.Log("picked");
                    
                    // 加入物品栏
                    string tag = obj.tag;
                    Debug.Log(tag);
                    var item_sprite = obj.GetComponent<SpriteRenderer>().sprite;
                    itemBar.GetComponent<itemChoser>().AddNew(item_sprite, tag);

                    obj.GetComponent<Renderer>().enabled = false;
                }
            }
        }
    }
}
