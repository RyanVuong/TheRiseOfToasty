using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float speed = 5f;

    public AudioSource PlayerFire;


    bool shootRight = true;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnShoot()
    {
        GetComponent<Animator>().SetTrigger("Attack");
        // create new projectile
        GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        // shoot projectile in correct direction (right or left)
        if (shootRight)
        {
            rb.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(-1, 0) * speed, ForceMode2D.Impulse);
        }

        //Sound Effects
        if(!PlayerFire.isPlaying)
        {
            PlayerFire.Play();
        }
    }

    // Keep track of direction player is faced in to determine direction in which projectile should be thrown
    void OnMove(InputValue movementVal)
    {
        Vector2 movement = movementVal.Get<Vector2>();
        
        // Shoot left if player last moved left
        if (movement.x < 0)
        {
            shootRight = false;
        }
        else if (movement.x > 0) // else, shoot right if player last moved right
        {
            shootRight = true;
        }
    }
}