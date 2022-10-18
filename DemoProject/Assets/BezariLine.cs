using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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
	public float width = 2.0f;
	public Color color = new Color (0,0,0,1);

    // Start is called before the first frame update
    void Start()
    {
		Debug.Log("Start");
        lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer = gameObject.GetComponent<LineRenderer> ();
		lineRenderer.startColor = color;
		lineRenderer.endColor = color;
		lineRenderer.startWidth = 0.02f;
		lineRenderer.endWidth = 0.02f;
		
		p0 = new Vector3 (0, 0, 0);
		p1 = new Vector3 (0, -2, 0);
		p2 = new Vector3 (5, 0, 0);


		p3 = new Vector3 (0,-5,0);

		// CalculatePosition();
		// lineRenderer.positionCount = resultList.ToArray ().Length;
		// lineRenderer.SetPositions(resultList.ToArray());
		
		

    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetMouseButtonDown(0)){
			Vector3 mousePosInScreen = Input.mousePosition;
			Vector3 mousePosiInWorld = Camera.main.ScreenToWorldPoint(
				mousePosInScreen
			);
			Debug.Log(mousePosiInWorld);
			p0 = mousePosiInWorld;

			CalculatePosition();
			lineRenderer.widthMultiplier = width;
			lineRenderer.positionCount = resultList.ToArray ().Length;
			lineRenderer.SetPositions(resultList.ToArray());
		}

    }



	void CalculatePosition(){
		result = new Vector3 ();
		tvalue = 0.001f;
		int count = 0;
		while (resultList.ToArray ().Length!=0){
			resultList.Remove(resultList[0]);
		}
		for(;tvalue <= 1.0f;tvalue+=0.001f,count+=1){
			result.x = Mathf.Pow (1 - tvalue, 2) * p0.x + 2 * tvalue * Mathf.Pow (1 - tvalue, 1) * p1.x + Mathf.Pow (tvalue, 2) * p2.x;
			result.y = Mathf.Pow (1 - tvalue, 2) * p0.y + 2 * tvalue * Mathf.Pow (1 - tvalue, 1) * p1.y + Mathf.Pow (tvalue, 2) * p2.y;
			result.z = Mathf.Pow (1 - tvalue, 2) * p0.z + 2 * tvalue * Mathf.Pow (1 - tvalue, 1) * p1.z + Mathf.Pow (tvalue, 2) * p2.z;
			resultList.Add(result);

		}

	}



}
