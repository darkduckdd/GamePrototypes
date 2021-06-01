using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private static SceneTransition instance;
    private AsyncOperation loadingScene;
    private Animator _animator;
    private static bool _shouldPlayAnimation=false;


    void Start()
    {
        instance = this;
        _animator = GetComponent<Animator>();

        if (_shouldPlayAnimation) _animator.SetTrigger("sceneOpening");
    }

    public static void SwitchToScene(int levelScene)
    {
        instance._animator.SetTrigger("sceneClosing");
        instance.loadingScene = SceneManager.LoadSceneAsync(levelScene);
        instance.loadingScene.allowSceneActivation = false;
    }

    public void OnAnimationOver()
    {
        _shouldPlayAnimation = true;
        loadingScene.allowSceneActivation = true;
    }

}
