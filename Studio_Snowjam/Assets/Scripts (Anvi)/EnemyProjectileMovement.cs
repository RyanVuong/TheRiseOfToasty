using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileMovement : MonoBehaviour
{
    float lifetime = 0f;
    [SerializeField] float maxLifetime = 7f;
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
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
