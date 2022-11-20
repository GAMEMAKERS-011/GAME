using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelieverUnderTree : MonoBehaviour
{
    public bool isHit;//�Ƿ���������---��Ҫ������
    private float changed;//�Ƿ�Ҫ�ı������ж�����
    private Animator anim;
    public GameObject character;//Ů�����󣬻ᴥ���Ի�
    public GameObject egg1;
    public GameObject egg2;

    private GameObject deadImage;
  
    
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
        isHit = false;
       
    }
  
    void believerDie()
    {
        anim.enabled = false;
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
        if(Vector3.Distance(egg1.transform.position, transform.position) < 1.5)
        {
            egg1.SetActive(false);
           
            anim.SetFloat("die", 1);//��������
            isHit = true;
        }
        if (Vector3.Distance(egg2.transform.position, transform.position) < 1.5)
        {
            egg2.SetActive(false);
            
            anim.SetFloat("die", 1);//��������
            isHit = true;
        }

        if (Vector3.Distance(character.transform.position, transform.position) < 3)
        {
            if (!isHit)
            {
                anim.SetFloat("idle", 1);//��������Ů��վ��
                                         //��������Ի�
                                         //Todo
                                         //������������
                deadImage = GameObject.Find("deadImage");
                // deadImage.SetActive(true);
                Invoke("die",1);
            }
        }

    }

    void die(){
        GameObject.Find("deadWindow").SendMessage("die");
    }
    

}
