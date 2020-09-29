using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Загрузка игры");
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Выход из игры");
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Загрузка меню");
        SceneManager.LoadScene(0);
    }
}
