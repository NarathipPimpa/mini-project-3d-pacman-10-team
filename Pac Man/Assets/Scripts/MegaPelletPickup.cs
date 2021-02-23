using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaPelletPickup : MonoBehaviour
{

    public int value;


    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<EndGameTrigger>().gems += value;

            FindObjectOfType<GameManager>().AddGem();

            FindObjectOfType<HealthManager>().invincibilityCounter = 5;

            FindObjectOfType<HealthManager>().playerRenderer.enabled = false;

            FindObjectOfType<HealthManager>().flashCounter = FindObjectOfType<HealthManager>().flashLength;

            FindObjectOfType<HealthManager>().HealPlayer(FindObjectOfType<HealthManager>().maxHealth);

            Instantiate(pickupEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
