using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] AudioClip spawnedEnemySFX;

    [SerializeField] Text enemyCount; //3 color font
    [SerializeField] Text enemyCount1;
    [SerializeField] Text enemyCount2;

    public bool spawnLooping = true; //modified by WaveHandler
    private int count = 0; //for enemy count text 
    public int enemiesSpawned = 0; //read by WaveHandler
    private WaveHandler waveHandler; //for grabbing and copying enemySpawnCount
    
    void Awake()
    {
        waveHandler = GameObject.FindObjectOfType<WaveHandler>();
    }

    void Start()
    {
        count = waveHandler.enemySpawnCount;
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        do{
            decreaseCounter(); //decrease enemy count on screen
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX); //spawning sound FX
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
         
        }while(spawnLooping);

    }
    private void decreaseCounter()
    {
        count-=1;
        enemiesSpawned += 1;
        enemyCount.text = "Enemies remaining: " + count.ToString();
        enemyCount1.text = "Enemies remaining: " + count.ToString();
        enemyCount2.text = "Enemies remaining: " + count.ToString();
    }
}
