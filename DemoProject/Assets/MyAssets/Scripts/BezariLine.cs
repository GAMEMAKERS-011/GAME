using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//暴露了多个公共函数
//注意绘制坐标的转换
//LineRender使用的是像素坐标？
public class BezariLine : MonoBehaviour
{
	private LineRenderer lineRenderer;
	private Vector3 p0;
	private Vector3 p1;
	private Vector3 p2;
	private Vector3 p3;
	private Vector3 point;
	private Vector3 result;
	private List<Vector3> resultList = new List<Vector3> ();
	private float tvalue;
	private float width = 0.05f;
	private Color color = new Color (0,0,0,1);
	private bool moved = false;

	public void setColor(Color col){
		color = col;
	}

	//p0 1 2是从右到左侧 右侧断点可动 
	//p1根据0和2调节位置
	public void setPostions(List<Vector3> posArray){
		p0 = posArray[0];
		p1 = posArray[1];
		p2 = posArray[2];
	}
	
	public void setPos0(Vector3 p_0){
		p0 = p_0;
	}


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer = gameObject.GetComponent<LineRenderer> ();
		lineRenderer.startColor = color;
		lineRenderer.endColor = color;
		// lineRenderer.startWidth = width;
		// lineRenderer.endWidth = width;
		lineRenderer.widthMultiplier = width;
		p0 = new Vector3 (33, 12, 0);
		p1 = new Vector3 (38, 10, 0);
		p2 = new Vector3 (48, 10, 0);


		p3 = new Vector3 (0,-5,0);

		CalculatePosition();
		lineRenderer.positionCount = resultList.ToArray ().Length;
		lineRenderer.SetPositions(resultList.ToArray());
			

    }

    // Update is called once per frame
    void Update()
    {
		if(moved){
			Vector3 mousePosInScreen = Input.mousePosition;
			Vector3 mousePosiInWorld = Camera.main.ScreenToWorldPoint(
				mousePosInScreen
			);
			p0 = mousePosiInWorld;
			UpdateP1();
			CalculatePosition();
			lineRenderer.widthMultiplier = width;
			lineRenderer.positionCount = resultList.ToArray ().Length;
			lineRenderer.SetPositions(resultList.ToArray());		
		}

    }

	//指定方法构造p2点位置
	void UpdateP1(){

	}

	void CalculatePosition(){
		result = new Vector3 ();
		tvalue = 0.1f;
		float gap = tvalue;
		int count = 2;
		while (resultList.ToArray ().Length!=0){
			resultList.Remove(resultList[0]);
		}
		resultList.Add(p0);
		for(;tvalue <= 1.0f;tvalue+=gap,count+=1){
			result.x = Mathf.Pow (1 - tvalue, 2) * p0.x + 2 * tvalue * Mathf.Pow (1 - tvalue, 1) * p1.x + Mathf.Pow (tvalue, 2) * p2.x;
			result.y = Mathf.Pow (1 - tvalue, 2) * p0.y + 2 * tvalue * Mathf.Pow (1 - tvalue, 1) * p1.y + Mathf.Pow (tvalue, 2) * p2.y;
			result.z = 0;
			resultList.Add(result);

		}
		resultList.Add(p2);

	}



}
