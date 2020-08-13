using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] AudioClip spawnedEnemySFX;

    int enemyWaveCount;
    [SerializeField] Text enemyCount; //3 color font
    [SerializeField] Text enemyCount1;
    [SerializeField] Text enemyCount2;

    [SerializeField] int numOfEnemies = 5; //user defined num of enemies
    [SerializeField] Canvas winCanvas;
    int count = 1;                               //count of enemies
    bool looping = true;
    int deathCount = 0;

    void Start()
    {
        winCanvas.enabled = false;
        count = numOfEnemies;
        StartCoroutine(RepeatedlySpawnEnemies());
        
    }

    void Update(){
        checkCounter();
        if(deathCount >= numOfEnemies){
            WinScreen();
        }
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        do{
            decreaseCounter();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
         //   StartCoroutine(RepeatedlySpawnEnemies());
        }while(looping);

    }
//todo maybe just make a method to call and spawn. do the spawning with an if state elsewhere
    private void decreaseCounter()
    {
        print(count);
        count--;
        enemyCount.text = "Enemies remaining: " + count.ToString();
        enemyCount1.text = "Enemies remaining: " + count.ToString();
        enemyCount2.text = "Enemies remaining: " + count.ToString();
    }

    private void checkCounter(){
        if(count <= 0)
        {
            looping = false;
        }
        else { return; }
    }
    public void increaseDeathCount(){
        deathCount++;
        print("AHHHHHH");
    }
    private void intermissionScreen()
    {
        print("Intermission");
        looping = false;
        Invoke("restartWave",5f);
    }
    void restartWave(){
        print("wave restarted");
        looping = true;
        count = numOfEnemies;
        Invoke("spawnAgain",3f);
    }
    void WinScreen(){
        winCanvas.enabled = true;
        Time.timeScale = 0;
    }

}