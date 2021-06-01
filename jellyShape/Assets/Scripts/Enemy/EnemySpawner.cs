using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnTime = 3.0f;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

   
   private IEnumerator SpawnEnemy()
    {

        int randonInt = Random.Range(0, enemyPrefabs.Length);
        GameObject obj= Instantiate(enemyPrefabs[randonInt], enemyPrefabs[randonInt].transform.position, enemyPrefabs[randonInt].transform.rotation);
        obj.gameObject.SetActive(true);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnEnemy());
    } 
}
