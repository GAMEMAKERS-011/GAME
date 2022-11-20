using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIwindow : MonoBehaviour
{
    public GameObject deadImage;
    public GameObject items;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        deadImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            items.SetActive(false);
            deadImage.SetActive(true);
            Invoke("reset",2);
        }
    }

    void die(){
        isDead = true;
    }

    void reset(){
        SceneManager.LoadScene("Scene_1");
    }

}
