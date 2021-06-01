using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShapeChanger : MonoBehaviour
{
    [SerializeField] private ClickerZone _clickerZone;
    public enum  Shapes{
        Cube,
        Sphere,
        Pipe,
        Prism,
        Torus,
        Cylinder
    }
    public Shapes CurrentShape
    {
        get { return CurShape; }
    }

    private Shapes CurShape = Shapes.Cube;
    private void OnEnable()
    {
        _clickerZone.Click += ChangeShape;
    }

    private void OnDisable()
    {
        _clickerZone.Click -= ChangeShape;
    }

    public void ChangeShape()
    {
        transform.GetChild((int)CurShape).gameObject.SetActive(false);
        CurShape++;
        if ((int)CurShape > Enum.GetNames(typeof(Shapes)).Length-1)
        {
            CurShape -= Enum.GetNames(typeof(Shapes)).Length;
        }
        transform.GetChild((int)CurShape).gameObject.SetActive(true);
        /*switch (CurShape)
        {
            case Shapes.Cube:
              
             
                break;
            case Shapes.Sphere:
              
                break;
              
            case Shapes.Cylinder:
              
                break;
        }*/
    }
}
