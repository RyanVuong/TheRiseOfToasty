using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovement : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    private Vector3 startingPoint;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint = gameObject.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetInteger("Health", GetComponent<Health>().getCurHealth());
        if (player == null)
            return;
        if (chase == true)
            Chase();
        else
            ReturnStartPoint();
        //Flip();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            return;
        else
            return;
    }
}
