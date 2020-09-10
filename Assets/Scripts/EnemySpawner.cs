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

    int count = 10;                               //count of enemies
    bool looping = true;

    void Start()
    {

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
         
        }while(looping);

    }
    private void decreaseCounter()
    {
        print(count);
        count--;
        enemyCount.text = "Enemies remaining: " + count.ToString();
        enemyCount1.text = "Enemies remaining: " + count.ToString();
        enemyCount2.text = "Enemies remaining: " + count.ToString();
    }

}
//enemy spawner should only be doing one thing. 
//perhaps write a script that receives messages from both player health and enemy spawner
//if player health reaches 0, broadcast to script to end game
//same idea with enemy spawner