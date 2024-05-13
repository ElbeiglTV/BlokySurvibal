using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    
    
    

    public void Start()
    {
        
        StartCoroutine(SpawnEnemy());
    }

   

    IEnumerator SpawnEnemy()
    {
        if (enemyPrefab.activeSelf)
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(SpawnEnemy());

        }
        else
        {
             yield return new WaitForSeconds(spawnRate);
            enemyPrefab.SetActive(true);
            enemyPrefab.transform.position = transform.position;
            StartCoroutine(SpawnEnemy());
        }
       
        
    }
}
