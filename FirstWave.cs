using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWave : WaveState
{
    //private List<Enemy> enemiesInWave = new List<Enemy>();
    public int WAVECOUNT = 10;
    private float spawnInterval = 2.0f;
    private float timeUntilNextSpawn = 0.0f;
    public bool spawningWave;

    public override void StartWave()
    {
        Debug.Log("FIRST STATE BEGGINS");
        spawningWave = true;
        //SpawnEnemy();
    }

    public void Update()
    {
        Debug.Log("estoy aca");

        if (spawningWave)
        {
            if (timeUntilNextSpawn <= 0f)
            {
                SpawnEnemy();
                WAVECOUNT--;
                timeUntilNextSpawn = spawnInterval;
                if (/*enemiesInWave.Count <= 0 */ WAVECOUNT <= 0)
                {
                    UpdateWave();
                    spawningWave = false;
                }
            }
            else
            {
                timeUntilNextSpawn -= Time.deltaTime;
            }
        }
    }

    public override void UpdateWave()
    {
        Debug.Log("Logicade desarrollo");

    }
    private void SpawnEnemy()
    {
        //Vector3 spawnPosition = GetSpawnPosition(); // Implementa esto según tu diseño
        //Instantiate(currentWave.enemyPrefab, spawnPosition, Quaternion.identity);
        // Lógica para spawnear un nuevo enemigo
        // Agregar el nuevo enemigo a la lista enemiesInWave
        Debug.Log("Invocacion");
    }

    private void UpdateEnemies()
    {
        /* Lógica para actualizar el comportamiento de los enemigos en la oleada
        foreach (Enemy enemy in enemiesInWave)
        {
            // Actualizar el comportamiento de cada enemigo
        }*/
    }
}