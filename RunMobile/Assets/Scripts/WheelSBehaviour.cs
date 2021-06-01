using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSBehaviour : MonoBehaviour
{
    float curentTime = 0.0f;
    float x;
    void Update()
    {
        if (curentTime < 10.0)
        {
            curentTime += Time.deltaTime;
            x += Time.deltaTime * 100.0f;
            transform.rotation = Quaternion.Euler(x, 0, 0);
        }
    }
}
