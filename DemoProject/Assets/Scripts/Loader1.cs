using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance = null;
    private GameObject girl;
    private Vector3 playerPos;

     void Awake() {
        if(instance == null){
            instance = this;
        }
        else if(instance !=this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    void InitGame(){
        Debug.Log("init game");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
