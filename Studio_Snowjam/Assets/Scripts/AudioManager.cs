using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource MainLoop;
    public AudioSource GameOver;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver && !MainLoop.isPlaying)
        {
            GameOver.Stop();
            MainLoop.Play();
        }
        if (isGameOver && !GameOver.isPlaying)
        {
            MainLoop.Stop();
            GameOver.Play();
        }
    }
}
