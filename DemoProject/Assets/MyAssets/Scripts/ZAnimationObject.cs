using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZAnimationObject : MonoBehaviour
{
    public GameObject character;    // link an instance of the character to calculate the distance
    public GameObject animi;
    public GameObject manager;

    bool hasPlayed = false;

    void Start()
    {
        //infoWindow.SetActive(false);
        //animi.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        Animator ani = gameObject.GetComponent<Animator>();
        if (Vector3.Distance(character.transform.position, transform.position) < 5)
        {
            // need to change input manager in player setting
            if (Input.GetButtonDown("XButton"))
            {
                if(transform.tag=="shirt")
                {
                    manager.GetComponent<manager>().shirtCount += 1;
                }
                Debug.Log("Close distance and z button pressed!");
                if (hasPlayed == false)
                {
                    animi.GetComponent<Renderer>().enabled = true;
                    ani.Play("animation", 0, 0);
                    hasPlayed = true;
                    StartCoroutine(enumerator());
                }
            }
        }
    }
   
    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(0.3f);
        Animator ani = gameObject.GetComponent<Animator>();
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("animation"))
        {
            Debug.Log("����clear");
            while (ani.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                yield return null;
            }
            Debug.Log("�������");
            animi.GetComponent<Renderer>().enabled = false;
        }
    }
}
