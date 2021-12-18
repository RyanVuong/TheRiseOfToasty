using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootProjectile : MonoBehaviour
{
    [SerializeField] float timeDuration = 2f;
    [SerializeField] float desiredDistance = 15f;
    [SerializeField] GameObject projectile;

    [SerializeField] GameObject player;

    public AudioSource GunSounds;
    
    float timeElapsed = 0f;
    bool startShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= desiredDistance)
        {
            startShooting = true;
        }
        else
        {
            startShooting = false;
            timeElapsed = 0f;
        }

        if (startShooting)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= timeDuration)
            {
                shootProjectile();
                timeElapsed = 0f;
            }
        }
    }

    void shootProjectile()
    {
        if (gameObject.GetComponent<Health>().getCurHealth() != 1)
        {
            GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    
            if (!GunSounds.isPlaying)
            {
                GunSounds.Play();
            }
        }

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
