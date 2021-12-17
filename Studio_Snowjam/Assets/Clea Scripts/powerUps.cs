using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUps : MonoBehaviour
{
    public float multiplier = 1.4f;
    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup(Collider player)
    {
        //Spawn pick up effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply power up to player
        playerStats stats = player.GetComponent<playerStats>();
        stats.health *= multiplier;

        //Remove power up object
        Destroy(gameObject);
    }
}
