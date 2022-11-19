using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class operation : MonoBehaviour
{
    public GameObject operationImage;
    public GameObject titleImage;
    // Start is called before the first frame update
    void Start()
    {
        operationImage = GameObject.Find("operationImage");
        titleImage = GameObject.Find("titleImage");
    }

    // Update is called once per frame
    void Update()
    {
        //user input enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("oepration enter");
            operationImage.SetActive(false);
            titleImage.SetActive(true);
        }
    }
}
