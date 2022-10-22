using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_control : MonoBehaviour
{
    [Header("showed")]
    [SerializeField] private GameObject showed;

    [Header("Ink JOSON")]
    [SerializeField] private TextAsset InkJson;
    // Start is called before the first frame update
    private bool playerInRange;
    private void Awake()
    {
        playerInRange= false;
        showed.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            playerInRange = true;
        }
    }
    void Start()
    {
        if(GetComponent<Collider2D>().gameObject.tag=="Player")
        {
            playerInRange = false;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(Input.GetKeyDown("e"))
            {
                showed.SetActive(true);

            }
            
        }else
        {
            showed.SetActive(false);
        }
    }
}
