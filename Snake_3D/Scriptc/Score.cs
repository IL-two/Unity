using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public SnakeMmove SnakeMmove;
	public Text TextScore;
	public Text TextBestScore;

	void Start () {
		TextScore.text = "Score :" + SnakeMmove.score;
		TextBestScore.text = "Best Score :" + SnakeMmove.bestscore;
		
	}
	
	
	void Update () {
		
	}
}
