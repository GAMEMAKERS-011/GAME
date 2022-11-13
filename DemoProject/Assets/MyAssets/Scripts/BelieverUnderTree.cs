using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelieverUnderTree : MonoBehaviour
{
    public bool isHit;//是否有鸟蛋砸下---需要联动鸟巢
    private float changed;//是否要改变人物行动方向
    private Animator anim;
    public GameObject character;//女孩对象，会触发对话
    
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
        isHit = false;
    }
    void animationRightEnd()
    {
        
        anim.SetFloat("changed", 1);Vector3 cur = transform.localScale;
        transform.localScale = new Vector3(-cur[0], cur[1], cur[2]);

    }
    void animationLeftEnd()
    {
        anim.SetFloat("changed", 0);
        Vector3 cur = transform.localScale;
        transform.localScale = new Vector3(-cur[0], cur[1], cur[2]);
    }
    // Update is called once per frame
    void Update()
    {
        if(isHit)
        {
            anim.SetFloat("die", 1);//人物死亡
        }
        if(Vector3.Distance(character.transform.position, transform.position) < 5)
        {
            anim.SetFloat("idle", 1);//人物正对女孩站立
            //触发人物对话
            //Todo
            //进入死亡界面
        }

    }
}
