using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource TheMusic;
    void Start()
    {
        TheMusic.Play();
    }
    public void StopMusic()
    {
        TheMusic.Stop();
    }
}
