
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main game controller
/// </summary>
public class GameController : MonoBehaviour
{
    [Tooltip("Ссылка для спауна")]
    public Transform tile;

    [Tooltip("ссылка на преподствия")]
    public Transform obstacle;

    [Tooltip("Ссылка на деньги")]
    public Transform gem;

    [Tooltip("Начальная точка спауна")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("Как много плиток должны создать заранее")]
    [Range(0, 20)]
    public int initSpawnNum = 10;

    [Tooltip("Сколько плиток нужно породить изначально без каких-либо препятствий")]
    public int initNoObstacles = 5;

    /// <summary>
    /// Следуйшая точка спауна
    /// </summary>
    private Vector3 nextTileLocation;

    /// <summary>
    /// Как должна вращаться следующая плитка?
    /// </summary>
    private Quaternion nextTileRotation;


    private void Start()
    {
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextTile(i >= initNoObstacles);
        }
    }

    /// <summary>
    /// Будет вызывать плитки в определенное место и установливает позицию
    /// <paramref name="spawnObstacles"/>если нужно создать припятсвие
    /// </summary>
    public void SpawnNextTile(bool spawnObstacles = true)
    {
        var newTile = Instantiate(tile, nextTileLocation, nextTileRotation);

        var NextTile = newTile.Find("NextSpawnPoint");
        nextTileLocation = NextTile.position;
        nextTileRotation = NextTile.rotation;

        if (spawnObstacles)
        {
            SpawnObstacle(newTile);
        }
    }

    private void SpawnObstacle(Transform newTile)
    {
        var obstacleSpawnPoints = new List<GameObject>();
        //Пройдите через каждый из детских игровых объектов в нашей плитке
        foreach (Transform child in newTile)
        {
            if (child.CompareTag("ObstacleSpawn"))
            {
                obstacleSpawnPoints.Add(child.gameObject);
            }
        }

        if (obstacleSpawnPoints.Count > 0)
        {
            var spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Count)];
            var spawnPos = spawnPoint.transform.position;
            var newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);
            newObstacle.SetParent(spawnPoint.transform);
        }
    }

  
}
