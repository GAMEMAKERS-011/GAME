using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader_trig : MonoBehaviour
{
    public GameObject manager;
    private float timer;
    private bool beginTimer;
    private bool hitcat;
    private bool TimerStopped;
    void Start()
    {
        beginTimer = false;
    }
    public void stopTimer()
    {
        beginTimer = false;
        TimerStopped = true;
        manager.GetComponent<manager>().changedSucceed();
    }
    void beginHitCat()
    {
        manager.GetComponent<manager>().catLeave();
        hitcat = true;beginTimer = true;
        timer = 0f;
    }
    void Update()
    {
        if(hitcat)
        {
            manager.GetComponent<manager>().LeaderHigh();
           
            hitcat = false;
        }
        if(beginTimer)
        {
            timer += Time.deltaTime;
            if(timer>10)//����10s��ûȥ����
            {
                beginTimer = false;
                manager.GetComponent<manager>().changedSucceed();//ֱ��ȥ�ж��Ƿ�ɹ�����
            }
        }
    }

}
