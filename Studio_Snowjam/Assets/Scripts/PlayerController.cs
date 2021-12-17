using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private Vector2 position;

    private Rigidbody2D rb;
    private Animator animator;

    public bool grounded;
    public float speed;
    public float jumpHeight;
    public float dashFactor;
    private bool justDashed;
    private float originalHorizontal;
    private bool dashDone;
    private int dashedInAir;

    public AudioSource walking;
    Health health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = rb.position;
        grounded = false;
        justDashed = false;
        dashDone = false;
        dashedInAir = 0;
        health = gameObject.GetComponent<Health>();

    }

    void OnMove(InputValue movementVal)
    {
        // horizontal = 0;
        // vertical = 0;
        Vector2 movement = movementVal.Get<Vector2>();
        horizontal = movement.x * speed;
        
        // Face left if player start to move left
        if (movement.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (movement.x > 0) // Else face right.
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (movement.y > 0 && grounded)
        {
            // Debug.Log("JUMPING!");
            vertical = jumpHeight;
        }

        if (movement.y < 0 && !grounded)
        {
            if (vertical > 0)
            {
                vertical = 0;
            }

            vertical += movement.y * speed;
        }
        //Sound Effects
        if (grounded && movement.x != 0 && !walking.isPlaying)
        {
            walking.Play();
        }
        else if (movement.x == 0)
        {
            walking.Stop();
        }
    }

    void OnDash()
    {
        if (Mathf.Abs(horizontal) > 1 && !justDashed && dashedInAir < 2 && !grounded)
        {
            justDashed = true;
            originalHorizontal = horizontal;
            dashedInAir += 1;
        }
    }

    void OnFastFall()
    {
        if (!grounded)
        {
            // Debug.Log("Fast Falling");
            if (vertical > 0)
            {
                vertical = 0;
            }

            vertical -= 10;
        }
    }


    void FixedUpdate()
    {
        
        if (justDashed)
        {
            if (originalHorizontal > 0)
            {
                horizontal += dashFactor / 4;
            }
            else
            {
                horizontal -= dashFactor / 4;
            }
        }

        rb.velocity = new Vector2(horizontal, vertical <= 0 ? rb.velocity.y + vertical : vertical);
        vertical = 0;
        if (justDashed)
        {
            if ((originalHorizontal > 0 && horizontal > originalHorizontal + dashFactor) ||
                (originalHorizontal < 0 && horizontal < originalHorizontal - dashFactor))
            {
                dashDone = true;
            }
        }

        if (dashDone)
        {
            Debug.Log("FINISHED DASH");
            if (originalHorizontal > 0)
            {
                horizontal -= (dashFactor + 8);
            }
            else
            {
                horizontal += (dashFactor + 8);
            }

            justDashed = false;
            dashDone = false;
        }
        //float horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
        if(collision.gameObject.CompareTag("Enemy")){
            health.Damage(1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Floor")) return;
        grounded = false;
        dashedInAir = 0;
    }
}