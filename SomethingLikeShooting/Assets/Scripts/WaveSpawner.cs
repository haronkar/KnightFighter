using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public static int enemieskilled = 0;
    public static int waveIndex = 0;


    public float timeBetweenWaves = 5f;
    public float countdown = 3f;
    public int enemyPerWave;

    public Transform[] spawnPoints;
    public Transform[] enemy;

    public PauseScript panel;
    public Text spawnText;
    public GameObject textObj;
    public GameObject chest;

    private void Start()
    {
        enemiesAlive = 0;
        enemieskilled = 0;
        waveIndex = 0;
}
    private void Update()
    {

        if (enemiesAlive > 0)
            return;
        

        if (countdown <= 0f)
        {

            if (enemiesAlive == 0)
            {
                float randomX = Random.Range(-21, 21);
                float randomY = Random.Range(-21, 21);
                Instantiate(chest, new Vector3(randomX, randomY, 0), Quaternion.identity);

                waveIndex++;
                enemyPerWave = 13 + waveIndex * 2;
                
            }
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        enemiesAlive = enemyPerWave;

        Debug.Log("Wave :: " + waveIndex);
        spawnText.text = "WAVE : " + waveIndex.ToString();
        textObj.SetActive(true);
        yield return new WaitForSeconds(6f);
        textObj.SetActive(false);

        for (int i = 0; i < enemyPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds (1f);
        }
        
        PauseScript.isActive = false;
    }

    void SpawnEnemy()
    {
        int rand = Random.Range(0, spawnPoints.Length - 1);
        int rand2 = Random.Range(0, enemy.Length);
        Instantiate(enemy[rand2], spawnPoints[rand].position, spawnPoints[rand].rotation);
    }

    
}
