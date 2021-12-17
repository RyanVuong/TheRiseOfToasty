using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    float lifetime = 0f;
    [SerializeField] float maxLifetime = 7f;
    [SerializeField] float speed = 8f;
    [SerializeField] private int attackDmg = 1;

    GameObject player;
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        /*
        // determine positions of player and projectile
        Vector2 playerPosition = player.transform.position;
        Vector2 projectilePosition = gameObject.transform.position;

        // find difference in positions to determine direction in which projectile should travel
        Vector2 projectileDirection = (playerPosition - projectilePosition).normalized;

        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(projectileDirection * speed, ForceMode2D.Impulse);
        */

        player = GameObject.Find("Toasty");
        target = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // move projectile
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        if ((transform.position.x == target.x) && (transform.position.y == target.y))
        {
            Destroy(gameObject);
        }

        // destroy projectile after exceeding lifetime (if it did not hit anything)
        lifetime += Time.deltaTime;
        if (lifetime >= maxLifetime)
        {
            Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Deals damage if it hits the player
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().Damage(attackDmg);
        }

        Destroy(gameObject);
    }
    
    int GetAttackDmg()
    {
        return attackDmg;
    }
    
    void SetAttackDmg(int dmg)
    { 
        attackDmg = dmg;
    }
}
