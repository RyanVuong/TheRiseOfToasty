using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileMovement : MonoBehaviour
{
    float lifetime = 0f;
    [SerializeField] float maxLifetime = 15f;
    [SerializeField] float speed = 8f;
    GameObject player;
    Vector3 target;

    private Vector3 normalizeDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Toasty");
        target = player.transform.position;
        normalizeDirection = (target - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // move projectile
        float step = speed * Time.deltaTime;
        transform.position += normalizeDirection * speed * Time.deltaTime;

        // destroy projectile after exceeding lifetime (if it did not hit anything)
        lifetime += Time.deltaTime;
        if (lifetime >= maxLifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "EnemyProjectile")
            Destroy(gameObject);
    }
}
