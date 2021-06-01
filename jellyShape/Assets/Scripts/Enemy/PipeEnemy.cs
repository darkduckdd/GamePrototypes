using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeEnemy : Enemy
{

    private void OnTriggerEnter(Collider other)
    {
        ShapeChanger shapeChanger = other.GetComponentInParent<ShapeChanger>();
        if(shapeChanger == null)
        {
            return;
        }

        if (shapeChanger.CurrentShape == ShapeChanger.Shapes.Pipe)
        {
            ScoreManager.instance.Plumber = +1;
        }
        else
        {
            ScoreManager.instance.Plumber = 0;
            GameOver();
        }
    }

}
