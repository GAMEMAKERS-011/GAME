using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grand_control : MonoBehaviour
{
    public GameObject character;
    public GameObject actGirl;
    public GameObject manager;
    private Animation pullgirl;
    private Collider2D coll;
    public GameObject vase;
    private bool onlyonce;//该类中的流程只发生一次
    // Start is called before the first frame update
    void Start()
    {
        onlyonce = true;
        pullgirl = GetComponent<Animation>();
        coll = GetComponent<Collider2D>();
        
    }
    void GrandDie()
    {
        pullgirl.enabled=false;
        coll.enabled = false;
    }
    void GrandCatchEnd()
    {
        //女孩与grand全部消失
        actGirl.SetActive(false);
        character.SetActive(false);
        manager.GetComponent<manager>().GrandmaEnd();
        
    }
    void GrandMoveToGril()
    {
        //girl的代码开始执行
        actGirl.SetActive(true);
         
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(vase.transform.position, transform.position)<5)//花瓶砸下
        {
            onlyonce = false;//后面不会再伤害小女孩
            vase.SetActive(false);
            pullgirl.Play("grandma_down");
        }
        if (onlyonce && Vector3.Distance(character.transform.position, transform.position) < 2)
        {
            Vector2 girlPosi = character.transform.position;
            character.GetComponent<Character_controller>().inActive = false;//小女孩不能动，开始过剧情
            character.SetActive(false);
            
            actGirl.transform.position = girlPosi;

            girlPosi.x = (float)girlPosi.x+1.8f;
            transform.position = girlPosi;

            pullgirl.Play("grandma_pull");
            onlyonce = false;

        }
    }


}
