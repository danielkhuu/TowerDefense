using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

    //Tower State
    Transform targetEnemy;

    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy) //if a target exists, look at enemy and begin firing process
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else //if no enemy, stop shooting
        {
            Shoot(false);
        }

    }
    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>(); //any object with that cs is a damagable enemy
        if(sceneEnemies.Length ==0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform; //defaults 1sts sceneEnemies as closest

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform); //comparing closetEnemy and next 
        }
        targetEnemy = closestEnemy; 
    }
    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transformA.position, transform.position);
        var distToB= Vector3.Distance(transformB.position, transform.position);
        if(distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }

    private void FireAtEnemy()
    {                                           //enemy position,         tower position
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if(distanceToEnemy <= attackRange) 
        {
            Shoot(true); //shoot if within range
        }
        else
        {
            Shoot(false); //dont shoot
        }
    }
    private void Shoot(bool isActive)
    {                           //emission tab of tower's particle system in inspector
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive; //turn on emission
    }
}
