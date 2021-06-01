using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public float timeCutScene = 3f;

    void Start()
    {
        Invoke("ChanceCamera", timeCutScene);
    }

  

    void ChanceCamera()
    {
        gameObject.SetActive(false);
    }
}
