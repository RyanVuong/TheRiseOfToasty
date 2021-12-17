using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    GameObject player;
    Transform pos;


    void Start()
    {
        player = GameObject.Find("Toasty");
        pos = player.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector3 position = pos.position;
        gameObject.transform.position = new Vector3(position.x, position.y, gameObject.transform.position.z);
    }
}
