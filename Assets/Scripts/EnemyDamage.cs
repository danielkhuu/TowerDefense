using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    EnemySpawner blah;
    
    AudioSource myAudioSource;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        blah = FindObjectOfType<EnemySpawner>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }
    private void ProcessHit()
    {
        hitPoints--;
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyHitSFX);

    }
    private void KillEnemy()
    {
        //important to instantiate before destroying
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();

        Destroy(vfx.gameObject, vfx.main.duration); //duration allows vfx to play before we destroy enemy
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position, .2f); //we use PlayCLipAtPoint instead of how we did it with enemyhitsfx bc
                                                                        //it will not get destroyed when the bottom line is called
                                                           //it plays audio in 3d space, place audio by camera, adjust volume
        Destroy(gameObject); //destroy enemy ship
        print("AHH");
        blah.increaseDeathCount();
    }
}
