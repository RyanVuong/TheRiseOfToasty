using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileMovement : MonoBehaviour
{
    float lifetime = 0f;
    [SerializeField] float maxLifetime = 7f;
    [SerializeField] private int attackDmg = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= maxLifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Deals damage if it hits the player
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            collision.gameObject.GetComponent<Health>().Damage(attackDmg);
        }
        Destroy(gameObject);
    }

    public int GetAttackDmg()
    {
        return attackDmg;
    }
    
    public void SetAttackDmg(int dmg)
    { 
        attackDmg = dmg;
    }

}
