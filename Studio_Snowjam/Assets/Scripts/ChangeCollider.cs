using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCollider : MonoBehaviour
{
    public BoxCollider2D player;
    Health health;
    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<BoxCollider2D>();
        health = gameObject.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.size);
        if(health.getCurHealth() == 2){
            player.size = new Vector2(0.96f, 1.3f);
            player.offset = new Vector2(0,-.35f);
        }
        if(health.getCurHealth() == 1){
            player.size = new Vector2(0.96f, 0.8f);
            player.offset = new Vector2(0,-.6f);
        }
        if(health.getCurHealth() == 3){
            player.size = new Vector2(0.96f, 1.91f);
            player.offset = new Vector2(0,0);
        }
    }
}
