using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grand_control : MonoBehaviour
{
    public GameObject character;
    public GameObject manager;
    private Animation pullgirl;
    public GameObject vase;
    private bool onlyonce;//该类中的流程只发生一次
    // Start is called before the first frame update
    void Start()
    {
        onlyonce = true;
        pullgirl = GetComponent<Animation>();
        
    }
    void GrandCatchEnd()
    {
        //女孩与grand全部消失
        character.GetComponent<Animator>().SetFloat("catch", 0);
        character.SetActive(false);
        manager.GetComponent<manager>().GrandmaEnd();
      
    }
    void GrandMoveToGril()
    {
        //girl的代码开始执行
          character.GetComponent<Animator>().SetFloat("catch", 1);
         
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(vase.transform.position, transform.position) < 2)//花瓶砸下
        {
            onlyonce = false;//后面不会再伤害小女孩
            pullgirl.Play("grandma_down");
        }
        if (onlyonce && Vector3.Distance(character.transform.position, transform.position) < 2)
        {
            character.GetComponent<Character_controller>().inActive = false;//小女孩不能动，开始过剧情
            Vector2 girlPosi = character.transform.position;
            girlPosi.x = (float)girlPosi.x+1.8f;
            transform.position = girlPosi;

            pullgirl.Play("grandma_pull");
            onlyonce = false;

        }
    }
}
