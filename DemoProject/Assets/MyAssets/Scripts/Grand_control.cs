using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grand_control : MonoBehaviour
{
    public GameObject character;
    public GameObject manager;
    private Animation pullgirl;
    public GameObject vase;
    private bool onlyonce;//�����е�����ֻ����һ��
    // Start is called before the first frame update
    void Start()
    {
        onlyonce = true;
        pullgirl = GetComponent<Animation>();
        
    }
    void GrandCatchEnd()
    {
        //Ů����grandȫ����ʧ
        character.GetComponent<Animator>().SetFloat("catch", 0);
        character.SetActive(false);
        manager.GetComponent<manager>().GrandmaEnd();
      
    }
    void GrandMoveToGril()
    {
        //girl�Ĵ��뿪ʼִ��
          character.GetComponent<Animator>().SetFloat("catch", 1);
         
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(vase.transform.position, transform.position) < 2)//��ƿ����
        {
            onlyonce = false;//���治�����˺�СŮ��
            pullgirl.Play("grandma_down");
        }
        if (onlyonce && Vector3.Distance(character.transform.position, transform.position) < 2)
        {
            character.GetComponent<Character_controller>().inActive = false;//СŮ�����ܶ�����ʼ������
            Vector2 girlPosi = character.transform.position;
            girlPosi.x = (float)girlPosi.x+1.8f;
            transform.position = girlPosi;

            pullgirl.Play("grandma_pull");
            onlyonce = false;

        }
    }
}
