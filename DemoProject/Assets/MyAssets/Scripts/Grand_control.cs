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
    public GameObject deadImage;
    private bool onlyonce;//�����е�����ֻ����һ��
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
        //Ů����grandȫ����ʧ
        actGirl.SetActive(false);
        character.SetActive(false);
        manager.GetComponent<manager>().GrandmaEnd();
        
    }
    void GrandMoveToGril()
    {
        //girl�Ĵ��뿪ʼִ��
        actGirl.SetActive(true);
         
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(vase.transform.position, transform.position)<5)//��ƿ����
        {
            onlyonce = false;//���治�����˺�СŮ��
            vase.SetActive(false);
            pullgirl.Play("grandma_down");
        }
        if (onlyonce && Vector3.Distance(character.transform.position, transform.position) < 2)
        {
            Vector2 girlPosi = character.transform.position;
            character.GetComponent<Character_controller>().inActive = false;//СŮ�����ܶ�����ʼ������
            character.SetActive(false);
            
            actGirl.transform.position = girlPosi;

            girlPosi.x = (float)girlPosi.x+1.8f;
            transform.position = girlPosi;

            pullgirl.Play("grandma_pull");
            onlyonce = false;

        }
    }


}
