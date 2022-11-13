using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelieverUnderTree : MonoBehaviour
{
    public bool isHit;//�Ƿ���������---��Ҫ������
    private float changed;//�Ƿ�Ҫ�ı������ж�����
    private Animator anim;
    public GameObject character;//Ů�����󣬻ᴥ���Ի�
    
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
            anim.SetFloat("die", 1);//��������
        }
        if(Vector3.Distance(character.transform.position, transform.position) < 5)
        {
            anim.SetFloat("idle", 1);//��������Ů��վ��
            //��������Ի�
            //Todo
            //������������
        }

    }
}
