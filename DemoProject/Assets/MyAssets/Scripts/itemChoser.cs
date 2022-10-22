using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemChoser : MonoBehaviour
{
    private int selected;
    private int lastSelected;
    private bool touched;
    private int capacity;
    public Image[] picFrame;
    public Image[] Itempics;

    private string[] tags;
    private Sprite mySprite;//物品栏方框
    private Sprite notSelect;//物品栏被选中方框
    private Sprite blank;//空图片
    void Start()
    {
        selected = 0;
        lastSelected = 0;
        touched = false;
        mySprite = Resources.Load("Selected", typeof(Sprite)) as Sprite;
        notSelect = Resources.Load("block", typeof(Sprite)) as Sprite;
        blank= Resources.Load("blank", typeof(Sprite)) as Sprite;
        capacity = 0;
        tags = new string[6];
        for(int i=0;i<6;i++)
        {
            tags[i] = "";
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1 pressed");
            if (selected == 1)
            {
                selected = 0;
            }
            else
            { selected = 1; }
            touched = true;
        }
        if (Input.GetKeyDown("2"))
        {
            if (selected == 2)
            {
                selected = 0;
            }
            else
            { selected = 2; }
            touched = true;
        }
        if (Input.GetKeyDown("3"))
        {
            if (selected == 3)
            {
                selected = 0;
            }
            else
            { selected = 3; }
            touched = true;
        }
        if (Input.GetKeyDown("4"))
        {
            if (selected == 4)
            {
                selected = 0;
            }
            else
            { selected = 4; }
            touched = true;

        }
        if (Input.GetKeyDown("5"))
        {
            if (selected == 5)
            {
                selected = 0;
            }
            else
            { selected = 5; }
            touched = true;
        }
        if (Input.GetKeyDown("6"))
        {
            if (selected == 6)
            {
                selected = 0;
            }
            else
            { selected = 6; }
            touched = true;
        }
        switchSelected();

    }
    void switchSelected()
    {
        if (touched&&(selected>0))
        {   
           
            Debug.Log("update Selected");
            Debug.Log(selected);
            Debug.Log("number of updated above---------");
            picFrame[selected-1].sprite =mySprite;
            if(lastSelected!=0)
            {
                picFrame[lastSelected-1].sprite = notSelect;
            }
            touched = false; 
            lastSelected = selected;
        }
        if(touched&&selected==0)
        {
            for(int i=0;i<6;i++)
            {
                picFrame[i].sprite = notSelect;

            }
            lastSelected = 0;
        }
    }
    
    /*
     * 约定一个物品的tag吧。
     * 每次往物品栏加入新物品的时候传入物品的图片item，以及该物品所对应的tag
     * 返回值：是否插入成功
     */
    public bool AddNew(Sprite item,string tag)
    {
        if(capacity>=6)
        {
            return false;
        }else
        {
            Itempics[capacity].sprite = item;
            tags[capacity] = tag;
            capacity++;
            return true;
        }
    }
    /*
     * 输入物品的tag，返回删除是否成功的bool
     */
    public bool DeleteItem(string tag)
    {
        if(capacity<=0)
        {
            return false;
        }else
        {
            Debug.Log("delete capacity");
            Debug.Log(capacity);
            bool findTag = false;
            for(int i=0;i<capacity;i++)
            {
                if(tags[i]==tag)
                {
                    Debug.Log("where find tag");
                    Debug.Log(i);
                    findTag = true;
                }
                if(findTag)
                {
                    if (i + 1 < capacity)
                    {
                        Itempics[i].sprite = Itempics[i + 1].sprite;
                        tags[i] = tags[i + 1];
                    }
                }
            }
            if(findTag)
            {
                Itempics[capacity - 1].sprite = blank;
            }
            return true;
        }
    }
    /*
     *得到物品栏中当前被选中的物品的tag，若未选中，返回-1 
     */
    public string GetSelected()
    {
        if (selected == 0)
        {
            return "no item";
        }
        else
        {
            return tags[selected - 1];
        }
    }
}
