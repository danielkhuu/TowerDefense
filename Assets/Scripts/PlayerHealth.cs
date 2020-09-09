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
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas winScreenCanvas;

    void Start()
    {
        winScreenCanvas.enabled = false;
        gameOverCanvas.enabled = false;
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
            gameOverCanvas.enabled = true;
            Time.timeScale = 0;
        }

    }
}
