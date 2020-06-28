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
    [SerializeField] Text enemyCount;
    [SerializeField] Text enemyCount1;
    [SerializeField] Text enemyCount2;
    [SerializeField] int numOfEnemies = 100;
    int count;

    void Start()
    {
        count = numOfEnemies;
        StartCoroutine(RepeatedlySpawnEnemies());
        enemyCount.text = "Enemies remaining: " + count.ToString();
        enemyCount1.text = "Enemies remaining: " + count.ToString();
        enemyCount2.text = "Enemies remaining: " + count.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {

        for(int i = 0; i<numOfEnemies;i++)
        {
            decreaseCounter();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
    private void decreaseCounter()
    {
        count--;
        enemyCount.text = "Enemies remaining: " + count.ToString();
        enemyCount1.text = "Enemies remaining: " + count.ToString();
        enemyCount2.text = "Enemies remaining: " + count.ToString();
    }
}