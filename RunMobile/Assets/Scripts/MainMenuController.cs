using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Button play;
    public Slider slider;
    public GameObject background;

    /// <summary>
    /// загрузка сцены при вызове
    /// </summary>
    /// <param name="levelName">имя сцены которую мы хотим загрузить</param>
    public void LoadLevel(string levelName)
    {
        LoadingScreen.SetActive(true);
        play.gameObject.SetActive(false);
        background.SetActive(false);
        //SceneManager.LoadScene(levelName);
        StartCoroutine(LoadAsync(levelName));

    }
    
    IEnumerator LoadAsync(string levelName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        while (!asyncLoad.isDone)
        {
            slider.value = asyncLoad.progress;
            yield return null;
        }
    }

    public void SwipeScene(string  nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
