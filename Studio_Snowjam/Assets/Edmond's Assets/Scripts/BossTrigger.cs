using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boss;
    // Start is called before the first frame update
    private int count = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && count == 0)
        {
            Instantiate(boss, gameObject.transform.position, Quaternion.identity);
            count++;
        }
    }
}
