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
        // Deals damage if it hits the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("pick up");
            collision.gameObject.GetComponent<Health>().Heal(healing);
            Destroy(gameObject);
        }
    }

    // public void setAttack()
    // {
    //     ref int CH = ref health.CurrentHealth();
    //     int attack = playerprojectilemovement.GetAttackDmg();
    //     playerprojectilemovement.SetAttackDmg(attack + CH - health.MaxHealth());
    //
    // }
}