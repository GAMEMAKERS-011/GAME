using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staff : MonoBehaviour
{
    public GameObject staffImage;
    public GameObject titleImage;
    // Start is called before the first frame update
    void Start()
    {
        staffImage = GameObject.Find("staffImage");
        titleImage = GameObject.Find("titleImage");
    }

    // Update is called once per frame
    void Update()
    {
        //user input enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("oepration enter");
            staffImage.SetActive(false);
            titleImage.SetActive(true);
        }
    }
}
