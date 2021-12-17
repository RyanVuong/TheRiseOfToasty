using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Shoot : MonoBehaviour
{
    private const int numEruptions = 15;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject Eruptprojectile;
    private GameObject[] eruptions = new GameObject[numEruptions];

    public void shootProjectile()
    {
        //GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        //Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        StartCoroutine(ShootTwo());

        /*
        // determine positions of player and projectile
        Vector2 playerPosition = player.transform.position;
        Vector2 projectilePosition = newProjectile.transform.position;

        // find difference in positions to determine direction in which projectile should travel
        Vector2 projectileDirection = (playerPosition - projectilePosition).normalized;

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.AddForce(projectileDirection * speed, ForceMode2D.Impulse);
        */
    }

    IEnumerator ShootTwo()
    {
        GetComponent<ToasterSFX>().PlayToasterShoot();
        GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        yield return new WaitForSeconds(0.3f);

        GetComponent<ToasterSFX>().PlayToasterShoot();
        newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public void angyShootProjectiles()
    {
        StartCoroutine(ShootThree());
    }

    IEnumerator ShootThree()
    {
        GetComponent<ToasterSFX>().PlayToasterShoot();
        GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        yield return new WaitForSeconds(0.2f);

        GetComponent<ToasterSFX>().PlayToasterShoot();
        newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        yield return new WaitForSeconds(0.2f);

        GetComponent<ToasterSFX>().PlayToasterShoot();
        newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    public void Erupt()
    {
        StartCoroutine(ShootErupt());   
    }


    IEnumerator ShootErupt()
    {
        for(int i = 0; i < numEruptions; i++)
        {
            GetComponent<ToasterSFX>().PlayToasterFire();
            eruptions[i] = Instantiate(Eruptprojectile, gameObject.transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(eruptions[i].GetComponent<Collider2D>(), GetComponent<Collider2D>());
            yield return new WaitForSeconds(Random.Range(0.15f, 0.3f));
        }
    }
}
