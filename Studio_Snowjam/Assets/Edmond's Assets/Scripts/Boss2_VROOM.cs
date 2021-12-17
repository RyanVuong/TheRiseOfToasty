using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_VROOM : StateMachineBehaviour
{
    private float duration;

    private float timeElapsed = 0f;

    enum Direction { left = -1, right = 1 };
    private Rigidbody2D rb;
    //private Animator animator;
    public float speed;
    private bool grounded;
    public bool canJump;
    public float jumpHeight;

    // Initial orientation of the sprite renderer
    private Vector3 initScale;

    // Set boundaries for patrol
    [SerializeField] private Vector3 leftEdge;
    [SerializeField] private Vector3 rightEdge;

    // Check if we're moving in a certain direction
    private bool movingLeft;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        duration = Random.Range(7f, 10f);
        rb = animator.GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        initScale = animator.transform.localScale;
        movingLeft = true;
        grounded = true;
        animator.GetComponent<ToasterSFX>().PlayToasterVroom();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Mathf.Abs(rb.velocity.y) == 0.0)
        {
            grounded = true;
        }
        else
            grounded = false;

        timeElapsed += Time.deltaTime;
        if (timeElapsed >= duration)
        {
            if (animator.GetComponent<Health>().getCurHealth() <= 25.0)
                animator.SetTrigger("Eruption");
            animator.SetTrigger("Attack");
            timeElapsed = 0.0f;
        }
        if (movingLeft)
        {
            // If we hit the boundary, have the enemy switch direction
            if (animator.transform.position.x < leftEdge[0])
                movingLeft = false;
            Move(animator, Direction.left);
        }
        else
        {
            if (animator.transform.position.x > rightEdge[0])
                movingLeft = true;
            Move(animator, Direction.right);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


    void Move(Animator animator, Direction dir)
    {
        if (timeElapsed <= 2.0f)
            return;
        // Set animator boolean for movement
        //animator.SetBool("isRunning", true);
        float slowdown = 1;
        /*
        float distToEdge = Mathf.Min(Mathf.Abs(animator.transform.position.x - leftEdge[0]), Mathf.Abs(animator.transform.position.x - rightEdge[0]));
        if(distToEdge < 3.0f)
        {
            Debug.Log(distToEdge);
            slowdown = Mathf.Max(distToEdge / 3.0f, 0.5f);
        }
        */
 
        switch (dir)
        {
            case Direction.left:
                // Keep initial orientation of sprite is moving left
                animator.transform.localScale = new Vector3(Mathf.Abs(initScale.x) * -1, initScale.y, initScale.z);
                break;
            case Direction.right:
                // Otherwise, we flip the sprite
                animator.transform.localScale = new Vector3(Mathf.Abs(initScale.x), initScale.y, initScale.z);
                break;
        }
        if (timeElapsed % 3 < 0.1 && grounded)
            rb.velocity = new Vector2(slowdown * speed * (int)dir, rb.velocity.y + jumpHeight);
        else
            rb.velocity = new Vector2(slowdown * speed * (int)dir, rb.velocity.y);
    }
}
