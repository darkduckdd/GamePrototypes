using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlay : MonoBehaviour
{

    public void PlaytGame(int sceneLevel)
    {
        SceneTransition.SwitchToScene(sceneLevel);
    }
}
