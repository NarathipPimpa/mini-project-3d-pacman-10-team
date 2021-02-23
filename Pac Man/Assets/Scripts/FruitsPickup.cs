using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsPickup : MonoBehaviour
{

    public int value;

    public int healAmount;

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
            FindObjectOfType<GameManager>().AddScore(value);

            FindObjectOfType<HealthManager>().HealPlayer(healAmount);

            Instantiate(pickupEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }


}
