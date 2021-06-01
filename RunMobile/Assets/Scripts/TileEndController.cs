using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Создает новые плитки и уничтожает старые
/// </summary>
public class TileEndController : MonoBehaviour
{
    [Tooltip("как долго ждать до уничтожение")]
    public float destroyTime = 1.5f;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<CarMovement>())
        {
            GameObject.FindObjectOfType<GameController>().SpawnNextTile();
        }
        Destroy(transform.parent.gameObject, destroyTime);
    }
}
