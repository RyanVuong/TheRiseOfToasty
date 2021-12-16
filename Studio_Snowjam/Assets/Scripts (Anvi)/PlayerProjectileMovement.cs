using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileMovement : MonoBehaviour
{
    float lifetime = 0f;
    [SerializeField] float maxLifetime = 7f;
    [SerializeField] float speed = 5f;

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {

        // player.transform.right
        // new Vector2(1,0)

        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
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
