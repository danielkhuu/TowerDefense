using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas winScreenCanvas;
    public int enemySpawnCount = 5; //copied in EnemySpawner
    public int enemyDeathCount = 0; //modified in EnemyDamage
    private EnemySpawner enemySpawner; //for grabbing spawnLooping and enemiesSpawned

    void Awake()
    {
        enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        gameOverCanvas.enabled = false;
        winScreenCanvas.enabled = false;
    }

    void Update()
    {
        checkEnemySpawnedCount();
        checkEnemyDeaths();
    }
    private void checkEnemySpawnedCount() //stops spawn loop
    {
        if (enemySpawner.enemiesSpawned >= enemySpawnCount)
        {
            enemySpawner.spawnLooping = false;
        }
    }
    private void checkEnemyDeaths() //displays winScreenCanvas if all enemies destroyed
    {
        if(enemyDeathCount >= enemySpawnCount)
        {
            winScreenCanvas.enabled = true;
        }
    }
}

/*
 * TODO
 * Read playerhealth to stop game
 * 
 */