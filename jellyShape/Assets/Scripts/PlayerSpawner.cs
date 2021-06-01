using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
   
    void Start()
    {
        PoolPlayerSpawner(playerPrefabs);
        transform.GetChild(0).gameObject.SetActive(true);
       
    }
    private void PoolPlayerSpawner(GameObject[] objs)
    {
        
        for(int i=0;i<playerPrefabs.Length;i++)
        {
            GameObject obj = Instantiate(playerPrefabs[i], Vector3.zero, playerPrefabs[i].transform.rotation) as GameObject;
            obj.gameObject.SetActive(false);
            obj.transform.parent = transform;
            obj.transform.localPosition = Vector3.zero;
        }
    }
}
