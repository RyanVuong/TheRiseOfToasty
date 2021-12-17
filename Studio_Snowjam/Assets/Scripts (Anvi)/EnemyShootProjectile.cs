using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootProjectile : MonoBehaviour
{
    [SerializeField] float timeDuration = 3f;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject projectile;

    [SerializeField] GameObject player;
    
    float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeDuration)
        {
            shootProjectile();
            timeElapsed = 0f;
        }
    }

    void shootProjectile()
    {
        GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        /*
        // determine positions of player and projectile
        Vector2 playerPosition = player.transform.position;
        Vector2 projectilePosition = newProjectile.transform.position;

        // find difference in positions to determine direction in which projectile should travel
        Vector2 projectileDirection = (playerPosition - projectilePosition).normalized;

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.AddForce(projectileDirection * speed, ForceMode2D.Impulse);
        */
    }
}
