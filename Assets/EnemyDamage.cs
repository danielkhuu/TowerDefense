using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("Im hit");
        ProcessHit();
    }
    private void ProcessHit()
    {
        hitPoints--;
        print("Current hitpoints " + hitPoints);
    }
}
