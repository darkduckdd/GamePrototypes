using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusEnemy : Enemy
{
    private void OnTriggerEnter(Collider other)
    {
        ShapeChanger shapeChanger = other.GetComponentInParent<ShapeChanger>();
        if (shapeChanger == null)
        {
            return;
        }

        if (shapeChanger.CurrentShape == ShapeChanger.Shapes.Sphere)
        {
            ScoreManager.instance.Plumber = +1;
        }
        else
        {
            GameOver();
        }
    }
}
