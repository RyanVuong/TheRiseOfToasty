using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToasterSFX : MonoBehaviour
{
    public AudioSource ToasterVroom;
    public AudioClip tshoot;
    public AudioSource ToasterShoot;
    public AudioClip tfire;
    public AudioSource ToasterFire;

    public void PlayToasterVroom()
    {
        ToasterVroom.Play();
    }

    public void PlayToasterShoot()
    {
        ToasterShoot.PlayOneShot(tshoot);
    }

    public void PlayToasterFire()
    {
        ToasterFire.PlayOneShot(tfire);
    }
}
