using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public float speed;
	public Text ValueText;
	public Text MasterVolumeText;

	public void OnGameRestart()
	{
		Application.LoadLevel("Game");
	}
	public void OnGameStart()
	{
		PlayerPrefs.SetFloat("Speed", speed);
		PlayerPrefs.Save();
		Debug.Log("SaveSpeed");
		Application.LoadLevel("Game");			
	}

	public void OnClearResults ()
	{
			PlayerPrefs.DeleteKey("BestScore");
				PlayerPrefs.Save ();
				Debug.Log("Delete");
				Application.LoadLevel ("MainMenu");
	}

	public void OnExitGame()
	{
		Application.Quit();
	}

	public void OnSpeedVaule(float value)
	{
		speed = value;
		ValueText.text = "" + value;
	} 
	public void OnMasterVolume(float value)
	{
		MasterVolumeText.text = "" + value;
	}
	public void OnMainMenu()
	{
		Application.LoadLevel("MainMenu");
	}
}
