using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootProjectile : MonoBehaviour
{
    [SerializeField] float timeDuration = 3f;
    [SerializeField] GameObject projectile;
    
    float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeDuration)
        {
            shootProjectile();
            timeElapsed = 0f;
        }
    }

    void shootProjectile()
    {
        GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
