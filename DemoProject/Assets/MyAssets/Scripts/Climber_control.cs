using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber_control : MonoBehaviour
{
    public GameObject manager;
    public bool climbLadder;
    // Start is called before the first frame update
    private Animator anim;
    private bool climbup;
    private bool climbdown;
    private Rigidbody2D rig;
    public int speed;
    private float treeTop;
    private float treeBottom;
    private float ladderTop;
    private float ladderBottom;
    void Start()
    {
        climbup = false;
        climbdown = false;
        
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        treeTop = 17.51f;
        treeBottom = 5.73f;
        ladderTop = 13.46f;
        ladderBottom = 6.46f;
    }
    private void Update()
    {


            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                manager.GetComponent<manager>().climbToGirl(-1);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                manager.GetComponent<manager>().climbToGirl(1);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("climb up");
                climbup = true;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Debug.Log("jump up end");
                climbup = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("climb down");
                climbdown = true;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Debug.Log("climb down end");
                climbdown = false;
            }
            if ((!climbup) && (!climbdown))
            {
                anim.SetFloat("climb", 0);
            }
            UpdateVelocity();
        

    }
    void UpdateVelocity()
    {
        rig.velocity = new Vector2(0, 0);
        if (climbup)
        {
            if (climbLadder)
            {
                if (transform.position[1] <= ladderTop)
                {
                    rig.velocity = new Vector2(0, speed);
                }
                else
                {//ÇÐ»»»ØÈËÎï
                    climbLadder = false;
                    manager.GetComponent<manager>().climbEnd();
                    climbup = false;
                }
            }
            else
            {
                if (transform.position[1] <= treeTop)
                {
                    rig.velocity = new Vector2(0, speed);
                }
            }
            anim.SetFloat("climb", 1);

        }
        if (climbdown)
        {
            if (climbLadder)
            {
                if (transform.position[1] >= ladderBottom)
                {
                    rig.velocity = new Vector2(0, -speed);
                    anim.SetFloat("climb", 1);
                }
                else
                {
                    climbdown = false;
                    climbLadder = false;
                    manager.GetComponent<manager>().climbToGirl(0);
                }
            }
            if (transform.position[1] >= treeBottom)
            {
                rig.velocity = new Vector2(0, -speed);
                anim.SetFloat("climb", 1);
            }
            else
            {
                climbdown = false;
                manager.GetComponent<manager>().climbToGirl(0);
            }
            


        }
    }
    // Update is called once per frame
}
