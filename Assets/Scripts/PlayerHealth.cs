using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] Text healthText1;
    [SerializeField] Text healthText2;
    [SerializeField] AudioClip playerDamageSFX;
    bool playerDead = false;
    void Start()
    {
        healthText.text = "BASE HP: " + health.ToString();
        healthText1.text = "BASE HP: " + health.ToString();
        healthText2.text = "BASE HP: " + health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        health -= healthDecrease;
        healthText.text = "BASE HP: " + health.ToString();
        healthText1.text = "BASE HP: " + health.ToString();
        healthText2.text = "BASE HP: " + health.ToString();
        GetComponent<AudioSource>().PlayOneShot(playerDamageSFX);
        HandleDeath();
    }
    public void HandleDeath()
    {
        if(health <= 0)
        {
            playerDead = true;  //read by WaveHandler
        }
    }
}
