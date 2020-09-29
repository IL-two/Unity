using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMmove : MonoBehaviour {

	public float speed;
	public float rotationspeed;
	public List<GameObject> tailObject = new List<GameObject> ();
	public Vector3 zoffset;
	public GameObject talePrefab;
	private CharacterController controller;
	public static int score = 0;
	public static int bestscore;
	public int indx;
	public Text TextScore;
	public Text TextBestScore;
	public float move;
	
	void Start () {
		
		score = 0;
		tailObject.Add(gameObject);
		indx = tailObject.IndexOf(gameObject);

		speed = PlayerPrefs.GetFloat("Speed");
		
		if (PlayerPrefs.HasKey("BestScore"))
		{
		bestscore = PlayerPrefs.GetInt("BestScore");
		}
		Debug.Log("Load");
		RotationSpeed();
		
	}
	
	void FixedUpdate ()
	{
		move = Input.GetAxisRaw("Horizontal");
		
	}
	void Update () {

		RotationSpeed();
		
		transform.Translate(Vector3.forward*speed*Time.deltaTime);

		if (move > 0)
		{
			transform.Rotate(Vector3.up*rotationspeed*Time.deltaTime);
		}

		if (move < 0)
		{
			transform.Rotate(Vector3.down*rotationspeed*Time.deltaTime);
		}	
							
		TextScore.text = "Score :" + score;
		TextBestScore.text = "Best Score :" + bestscore;

	}
	public void AddTale ()
	{
		score += 10;
				
		if(bestscore < score)
		{
			bestscore = score;
		}
		Vector3 newTalePos = tailObject[tailObject.Count-1].transform.position;
		newTalePos += zoffset;
		tailObject.Add(GameObject.Instantiate (talePrefab, newTalePos, Quaternion.identity) as GameObject);
		indx++;
		PlayerPrefs.SetInt("BestScore", bestscore);
		PlayerPrefs.Save();
		Debug.Log("Save");
	}

	void OnTriggerEnter (Collider other)
	{
	if (other.CompareTag("Food"))
	{
		speed = speed + 0.2f;			
	}
	
	if (other.CompareTag("Walls"))
			{
			Application.LoadLevel("GameOver");
			}
	if (other.CompareTag("Tail"))
	{
		if (indx > 2)
		{
			Application.LoadLevel("GameOver");
		}
	}
	}

	public void RotationSpeed()
	{
		if (speed <= 2)
		{
			rotationspeed = 200;
		}
		if (speed >= 4)
		{
			rotationspeed = 250;
		}
		if (speed >= 6)
		{
			rotationspeed = 300;
		}
		if (speed >= 8)
		{
			rotationspeed = 400;
		}
	}

}
