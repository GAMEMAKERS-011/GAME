using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber_control : MonoBehaviour
{
    public GameObject manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void AnimationEnd()
    {
        manager.GetComponent<manager>().climbEnd();

    }
    // Update is called once per frame
}
