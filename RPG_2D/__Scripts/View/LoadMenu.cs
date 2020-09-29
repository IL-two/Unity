using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenu : MonoBehaviour
{
    public GameObject loadMenu;
    public Slider slider;
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
        Time.timeScale = 1f;
    }

    IEnumerator LoadAsync(int index)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(index);

        loadMenu.SetActive(true);

        while(!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            slider.value = progress;

            yield return null;
        }
    }
}
