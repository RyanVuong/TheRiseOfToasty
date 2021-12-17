using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    float lifetime = 0f;
    [SerializeField] float maxLifetime = 7f;
    // [SerializeField] float speed = 5f;

    // [SerializeField] public GameObject player;

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
        Destroy(gameObject);
    }
}
