using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUps : MonoBehaviour
{
    public GameObject pickupEffect;

    public Health health;


    public void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "PowerUp")
        {
            Destroy(collision.gameObject);
            health.DamagePlayer(-1);
         }
    }

    public void setAttack()
    {
        ref int CH = ref health.CurrentHealth();
        ref int attack = ref <ScriptableObject>.Attack();
        attack += CH - health.MaxHealth();

    }

}


