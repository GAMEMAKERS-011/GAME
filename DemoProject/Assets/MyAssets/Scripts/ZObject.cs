using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZObject : MonoBehaviour
{
    public GameObject fallen_cross;
    public GameObject current_cross;
    public GameObject character;

    void Start()
    {
        //set fallen invisible
        fallen_cross.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(character.transform.position, transform.position) < 10)
        {
            if (Input.GetButtonDown("ZButton"))
            {
                fallen_cross.SetActive(true);
                current_cross.SetActive(false);
            }   
        }
    }
}
