using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide_control : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject manager;
    private Animation girlhang;
    private bool onlyonce;
    void Start()
    {
        onlyonce = true;
        girlhang = GetComponent<Animation>();
    }
    void SlideEnd()
    {
        manager.GetComponent<manager>().SliderEnd();
    }
    // Update is called once per frame
    void Update()
    {
        if(onlyonce)
        {
            girlhang.Play("girl_hang");
            onlyonce = false;
        }
    }
}
