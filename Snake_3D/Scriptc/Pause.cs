using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public float timer;
  public bool ispuse;
  public GameObject gameMenu;

void Update()
{
   Time.timeScale = timer;
   if (Input.GetKeyDown(KeyCode.Escape) && ispuse == false)
  {
   ispuse = true;
  }
   else if (Input.GetKeyDown(KeyCode.Escape) && ispuse == true)
  {
   ispuse = false;
  }
   if (ispuse == true)
  {
   timer = 0;
   gameMenu.SetActive(true);

  }
  else if (ispuse == false)
  {
   timer = 1f;
   gameMenu.SetActive(false);

  }
 }
 public void OnButtonBack(bool setactiv)
{
  ispuse = setactiv;
}
}
