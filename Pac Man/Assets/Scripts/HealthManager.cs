using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public PlayerController player;

    public float invincibilityLength;
    public float invincibilityCounter;

    public Renderer playerRenderer;
    public float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    public GameObject deathEffect;
    public Image blackScreen;
    private bool isFadeToBlack;
    private bool isFadeFromBlack;
    public float fadeSpeed;
    public float waitForFade;

    public HealthScript healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        player = FindObjectOfType<PlayerController>();

        respawnPoint = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }

            if (invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }

        }

        if (isFadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed* Time.deltaTime));
            if(blackScreen.color.a == 1f)
            {
                isFadeToBlack = false;
            }
        }

        if (isFadeFromBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (blackScreen.color.a == 0f)
            {
                isFadeFromBlack = false;
            }
        }

    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {

            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0 && FindObjectOfType<PlayerController>().livesCounter > 0)
            {
                FindObjectOfType<PlayerController>().livesCounter--;
                FindObjectOfType<GameManager>().Lives();
                Respawn();
            }
            else if (currentHealth > 0) 
            {

                player.KnockBack(direction);

                invincibilityCounter = invincibilityLength;

                playerRenderer.enabled = false;

                flashCounter = flashLength;
            }
            else
            {
                SceneManager.LoadScene("Game_Over");
            }
        }
       
    }

    public void Respawn()
    {
        healthBar.SetHealth(100);
        if(!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }
        
    }


    public IEnumerator RespawnCo()
    {
        
        isRespawning = true;
        player.gameObject.SetActive(false);
        Instantiate(deathEffect, player.transform.position, player.transform.rotation);

        yield return new WaitForSeconds(respawnLength);

        isFadeToBlack = true;

        yield return new WaitForSeconds(waitForFade);

        isFadeToBlack = false;
        isFadeFromBlack = true;
        
        isRespawning = false;

        player.gameObject.SetActive(true);
        player.transform.position = respawnPoint;
        currentHealth = maxHealth;

        invincibilityCounter = invincibilityLength;
        playerRenderer.enabled = false;
        flashCounter = flashLength;
    }

    private PlayerController FindGameObjectsWithTag(string v)
    {
        throw new NotImplementedException();
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        healthBar.SetHealth(currentHealth);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
