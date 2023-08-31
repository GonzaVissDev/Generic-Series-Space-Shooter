using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class WaveOne : WaveState
{
     [SerializeField] private Wave currentWave;
     [SerializeField] private Transform[] spawnPositions;
     private int spawnIndex = 0;
     private float timeUntilNextSpawn = 0.0f;
     public bool spawningWave;
     private EnemyManager enemyManager;
     int currentsEnemies = 0;

    public override void StartWave()
    {
        Debug.Log("FIRST STATE BEGGINS");
        spawningWave = true;
        enemyManager = EnemyManager.Instance;
    }

    private void Update()
    {
        UpdateWave();
    }

    public override void UpdateWave()
    {
        if (spawningWave)
        {
            if (timeUntilNextSpawn <= 0f)
            {
                SpawnEnemy();
                timeUntilNextSpawn = currentWave.spawnInterval;
                spawningWave = !CheckWaveComplete();
            }
            else
            {
                timeUntilNextSpawn -= Time.deltaTime;
            }
        }
    }
    private void SpawnEnemy()
    {
        if(currentsEnemies < currentWave.enemiesPrefab.Length)
        {
            Vector3 spawnPosition = spawnPositions[spawnIndex].position;
            spawnIndex = (spawnIndex + 1) % spawnPositions.Length;
            GameObject newEnemy = Instantiate(currentWave.enemiesPrefab[currentsEnemies], spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = transform;
            currentsEnemies++;
        }

    }

    public override bool CheckWaveComplete()
    {
        return currentsEnemies >= currentWave.enemiesPrefab.Length && enemyManager.ActiveEnemyCount == 0;
    }
}
