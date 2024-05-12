using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;
    public float spawnRadius = 5f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector3 randomSpawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(enemyPrefab, randomSpawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
