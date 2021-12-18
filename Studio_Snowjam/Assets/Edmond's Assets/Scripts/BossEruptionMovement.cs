using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEruptionMovement : MonoBehaviour
{
    float lifetime = 0f;
    [SerializeField] float maxLifetime = 12f;
    [SerializeField] float speed = 8f;
    GameObject player;
    Vector2 target;

    private Vector2 initpos;
    private Vector2 bezier;
    float count = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Toasty");
        initpos = new Vector2(transform.position.x, transform.position.y);
        target = new Vector2(player.transform.position.x, initpos.y - 3);
        bezier =  initpos + ((target + (new Vector2(Random.Range(-5.0f, 5.0f),0))) - initpos) / 2 + Vector2.up * Random.Range(15.0f, 20.0f); // Play with 5.0 to change the curve
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    // Update is called once per frame
    void Update()
    {
        // move projectile
        float step = speed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, target, step);
        transform.Rotate(0.0f, 0.0f, 180.0f * Time.deltaTime);
        if (count < 1.0f)
        {
            count += Random.Range(0.3f, 0.5f) * Time.deltaTime;

            Vector2 m1 = Vector2.Lerp(initpos, bezier, count);
            Vector2 m2 = Vector2.Lerp(bezier, target, count);
            transform.position = Vector2.Lerp(m1, m2, count);
        }
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
        if (!collision.gameObject.CompareTag("EnemyProjectile") && !collision.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
        }
    }
}
