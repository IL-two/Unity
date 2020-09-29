using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFood : MonoBehaviour {

	public GameObject foodPrefab;
	public float XSize = 8.5f;
	public float YSize = 8.5f;
	public GameObject curFood;
	public Vector3 curPos;
	
	void AddNewFood()
	{
	RandPos ();
	curFood = GameObject.Instantiate (foodPrefab, curPos, Quaternion.identity) as GameObject;
	}
	void RandPos (){

		curPos = new Vector3 (Random.Range (XSize * -1, XSize), 0.25f, Random.Range (YSize * -1, YSize));

	}
	
	void Update()
	{
		if (!curFood)
		{
			AddNewFood();
			
		}
		else 
		{
			return;
		}
	}
}