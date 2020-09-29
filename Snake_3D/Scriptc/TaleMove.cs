using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TaleMove : MonoBehaviour {

	public float speedTale;
	public Vector3 tailetarget;
	public GameObject tailTargetObj;
	public  SnakeMmove mainSnake;


	void Start()
	{
		mainSnake = GameObject.FindGameObjectWithTag("SnakeMain").GetComponent<SnakeMmove>();
		
		tailTargetObj = mainSnake.tailObject[mainSnake.tailObject.Count-2];
	
				
	}
	void Update ()
    {
		speedTale = mainSnake.speed * 2.5f;
		tailetarget = tailTargetObj.transform.position;
		transform.LookAt(tailetarget);
		transform.position = Vector3.Lerp(transform.position, tailetarget,Time.deltaTime*speedTale);
		
	
	 }
	
	  
}
