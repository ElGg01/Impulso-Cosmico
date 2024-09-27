using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitch : MonoBehaviour
{
    public float tiempoDeCambio = 1.5f;
    public float pitchFinal = 0.1f;

    private AudioSource audioSource;
    private float pitchInicial;
    private float tiempoTranscurrido = 0.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pitchInicial = audioSource.pitch;
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver == true)
        {
            if (tiempoTranscurrido < tiempoDeCambio)
            {
                float nuevoPitch = Mathf.Lerp(pitchInicial, pitchFinal, tiempoTranscurrido / tiempoDeCambio);
                audioSource.pitch = nuevoPitch;
                tiempoTranscurrido += Time.deltaTime;
            }
        }
    }
}