using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class powerUps : MonoBehaviour
{
    //public GameObject pickupEffect;

    [SerializeField] private int healing = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // heals player 1hp on pickup
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("pick up");
            collision.gameObject.GetComponent<Health>().Heal(healing);
        }
        Destroy(gameObject);
    }

    // If curHealth = maxHealth then add multiplyer to score
    // Multiplyer = to curHealth - maxHelth


}