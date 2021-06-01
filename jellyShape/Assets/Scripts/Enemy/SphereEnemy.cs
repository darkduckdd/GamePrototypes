using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemy :Enemy
{
  
    private void OnTriggerEnter(Collider other)
    {
        ShapeChanger shapeChanger = other.GetComponentInParent<ShapeChanger>();
        if (shapeChanger == null)
        {
            return;
        }

        if (shapeChanger.CurrentShape == ShapeChanger.Shapes.Torus)
        {
            ScoreManager.instance.Plumber = +1;
        }
        else
        {
            ScoreManager.instance.Plumber = 0;
            GameOver();
        }
    }

    public override void Move(Vector3 direction)
    {
        base.Move(-transform.right);
    }
}
