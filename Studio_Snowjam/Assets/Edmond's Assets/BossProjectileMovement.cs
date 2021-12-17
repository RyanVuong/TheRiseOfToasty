using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileMovement : MonoBehaviour
{
    float lifetime = 0f;
    [SerializeField] float maxLifetime = 7f;
    [SerializeField] float speed = 8f;
    GameObject player;
    Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
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
        Destroy(gameObject);
    }
}
