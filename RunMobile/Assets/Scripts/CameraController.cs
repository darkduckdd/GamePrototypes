using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Будет следит лицом к цели
/// </summary>
public class CameraController : MonoBehaviour
{
    [Tooltip("обьект за которым надо следит")]
    public Transform target;

    [Tooltip("Насколько смещена будет камера по отношению к цели")]
    public Vector3 offset = new Vector3(0, 5, -8);
    private  void Update()
    {
        if (target != null)
        {
            //Устоновить позицию сещенную от цели
            transform.position = target.position + offset;
            //изменить rotation к цели
            transform.LookAt(target);
        }

    }
}
