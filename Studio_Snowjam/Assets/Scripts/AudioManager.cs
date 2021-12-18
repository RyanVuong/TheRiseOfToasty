using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource MainLoop;
    public AudioSource GameOver;
    public GameObject gameover;
    bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameover = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover.activeInHierarchy && !MainLoop.isPlaying)
        {
            GameOver.Stop();
            MainLoop.Play();
        }
        if (gameover.activeInHierarchy && !GameOver.isPlaying)
        {
            MainLoop.Stop();
            GameOver.Play();
        }
    }
}
