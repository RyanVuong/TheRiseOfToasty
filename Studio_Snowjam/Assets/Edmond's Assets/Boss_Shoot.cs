using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shoot : MonoBehaviour
{
    [SerializeField] GameObject projectile;

    public void shootProjectile()
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
