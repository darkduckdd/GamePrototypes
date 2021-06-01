using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScreenBehaviour : MonoBehaviour
{
    public static bool paused;

    [Tooltip("Ссылка на объект меню паузы для включения/выключения")]
    public GameObject pauseMenu;

    /// <summary>
    /// Перезагружает наш текущий уровень, эффективно "перезапуская" игру
    /// </summary>
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Включит или выключит наше меню паузы
    /// </summary>
    /// <param name="isPaused"></param>
    public void SetPauseMenu(bool isPaused)
    {
        paused = isPaused;

        Time.timeScale = (paused) ? 0 : 1;
        pauseMenu.SetActive(paused);
    }
    void Start()
    {
        SetPauseMenu(false);
    }
}
