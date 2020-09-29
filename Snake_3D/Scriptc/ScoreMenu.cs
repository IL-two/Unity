using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMenu : MonoBehaviour {

	public SnakeMmove SnakeMmove;
	public Text TextBestScore;

	void Start () {
		SnakeMmove.bestscore = PlayerPrefs.GetInt("BestScore");
		TextBestScore.text = "Best Score " + SnakeMmove.bestscore;

	}


	void Update () {

	}
}
