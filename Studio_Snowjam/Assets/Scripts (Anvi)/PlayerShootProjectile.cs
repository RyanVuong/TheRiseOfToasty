using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectile : MonoBehaviour
{
    [SerializeField] GameObject projectile;

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
        // create new projectile
        GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
