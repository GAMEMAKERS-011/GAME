using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject girl;
    public GameObject climber;
    public GameObject grand;
    public GameObject slider;
   
    // Start is called before the first frame update
    void Start()
    { 

    }
    void SliderBegin()
    {
        
        girl.GetComponent<Character_controller>().inActive = false;//�������ﲻ����������ɵ�ǰ������ֹͣ��
        girl.SetActive(false);//�����ø�����object������
        slider.SetActive(true);
    }
    public void SliderEnd()
    {
        slider.SetActive(false);
        girl.SetActive(true);
        Vector2 newP = new Vector2();
        newP.x = 49.4f;newP.y = 10f;
        girl.GetComponent<Transform>().position = newP;

    }
    public void GrandmaEnd()
    {
        grand.SetActive(false);
        //Ů�������ߺ�Ľ���չʾ
    }
    void hasLadder()
    {
        climber.SetActive(true);
        girl.GetComponent<Character_controller>().inActive = false;//�������ﲻ����������ɵ�ǰ������ֹͣ��
        girl.SetActive(false);//�����ø�����object������
       
    }
    public void climbEnd()
    {
        climber.SetActive(false);
        girl.SetActive(true);
        girl.GetComponent<Character_controller>().inActive = true;
        girl.GetComponent<Character_controller>().climbEnd = true;
        Vector2 newP = climber.GetComponent<Transform>().position;
        newP.x = 30.7f;newP.y = 15.1f;
        girl.GetComponent<Transform>().position = newP;
    }
}
