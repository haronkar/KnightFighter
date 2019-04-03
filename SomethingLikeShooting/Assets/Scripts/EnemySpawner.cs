using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPos;
    public float nextSpawn = 1f;
    public float spawnTime = 1f;


    private void Update()
    {
        if(Time.time >= nextSpawn)
        {
            SpawnEnemy(enemyPrefab);
            nextSpawn = Time.time + spawnTime;
        }
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        int rand = Random.Range(0, spawnPos.Length - 1);

        Instantiate(enemyPrefab, spawnPos[rand].position, Quaternion.identity);
    }
}
