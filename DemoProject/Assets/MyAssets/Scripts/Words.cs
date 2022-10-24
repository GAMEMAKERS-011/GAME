using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Words : MonoBehaviour
{
    public Text showtext;  //对话框的内容text
    public GameObject Log; //对话框的panel

    public string[] texts={"累鼠了"};
    public float textSpeed = 0.05f; //每个字多久才能出现

    int index; //进行到了第几句话，用于实现基础功能
    bool textFinished; //判断对话是否结束
    string text;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        textSpeed = 0.05f; //每个字出来的间隔时0.05秒
        if (Input.GetButtonDown("InteractButton") && textFinished)
        {
            EndDialogue();//如果按下鼠标左键并且播放到了最后一句的话就启动结束对话的函数
        }
    }

    public void StartPlay(int i)
    {
        text=texts[i];
        StartCoroutine(SetTextUI());
    }

    IEnumerator SetTextUI() //协程函数的标准形式
    {
        textFinished = false; //正在播放，所以bool值为false
        showtext.text = ""; //可能上一个句子使用结束后还在text上，所以要清空
        for (int i = 0; i < text.Length; i++)
        //按照一句话的一个字慢慢来，如果没有到一句台词最后一个字的话就一直向后
        {
            showtext.text += text[i]; //往之前已经打出的台词中加进新的文字
            yield return new WaitForSeconds(textSpeed);//等待textSpeed后继续循环
        }
        textFinished = true; //如果跳出循环说明文字已经放完了，所以bool值是true
        index++; //这句话已经放完了，index++跳进下一句话
    }

    public void EndDialogue()
    {
        gameObject.SetActive(false);
        Log.SetActive(false);
        index = 0;
        return;
    }
}
