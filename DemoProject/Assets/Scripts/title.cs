using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour
{
    public GameObject[] checks;
    public GameObject[] sceneItems;
    public GameObject operationImage;
    public GameObject staffImage;
    public GameObject titleImage;
    

    private int checkNum;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < checks.Length; i++)
        {
            checks[i].SetActive(false);
        }
        //set scene items to false
        for (int i = 0; i < sceneItems.Length; i++)
        {
            sceneItems[i].SetActive(false);
        }

        checks[0].SetActive(true);
        checkNum = 0;
        operationImage = GameObject.Find("operationImage");
        staffImage = GameObject.Find("staffImage");
        titleImage = GameObject.Find("titleImage");

        operationImage.SetActive(false);
        staffImage.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //user input up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("up");
            for (int i = 0; i < checks.Length; i++)
            {
                if (checks[i].activeSelf)
                {
                    checks[i].SetActive(false);
                    if (i == 0)
                    {
                        checks[checks.Length - 1].SetActive(true);
                        checkNum = checks.Length - 1;
                        break;
                    }
                    else
                    {
                        checks[i - 1].SetActive(true);
                        checkNum = i - 1;
                        break;
                    }
                }
            }
        }

        //user input down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("down");
            for (int i = 0; i < checks.Length; i++)
            {
                if (checks[i].activeSelf)
                {
                    checks[i].SetActive(false);
                    if (i == checks.Length - 1)
                    {
                        checks[0].SetActive(true);
                        checkNum = 0;
                        break;
                    }
                    else
                    {
                        checks[i + 1].SetActive(true);
                        checkNum = i + 1;
                        break;
                    }
                }
            }
        }
        //user input enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("enter");
            titleImage.SetActive(false);
            //game start
            if (checkNum == 0)
            {
                Debug.Log("start");
                //set scene items to true
                for (int i = 0; i < sceneItems.Length; i++)
                {
                    sceneItems[i].SetActive(true);
                }

            }
            //operation
            else if (checkNum == 1)
            {
                operationImage.SetActive(true);
                Debug.Log("operation");

            }
            //staff
            else if (checkNum == 2)
            {
                staffImage.SetActive(true);
                Debug.Log("list");
            }
            //exit
            else if (checkNum == 3)
            {
                Debug.Log("exit");
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif

            }
        }
    }
}
