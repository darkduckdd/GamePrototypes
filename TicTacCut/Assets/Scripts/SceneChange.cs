using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeScene(int level)
    {
        SceneTransition.SwitchToScene(level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
