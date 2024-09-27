using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] public AudioSource soundSource;
    [SerializeField] public AudioClip soundClip;
    void Start()
    {
        soundSource.clip = soundClip;
    }

    public void Reproducir()
    {
        soundSource.Play();
    }
}