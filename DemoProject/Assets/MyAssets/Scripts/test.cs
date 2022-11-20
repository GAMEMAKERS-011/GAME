using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Vector3.Distance(character.transform.position, transform.position));
        if (Vector3.Distance(character.transform.position, transform.position) < 10)
        {
            SpriteRenderer sp = GetComponent<SpriteRenderer>();
            sp.color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            SpriteRenderer sp = GetComponent<SpriteRenderer>();
            sp.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
