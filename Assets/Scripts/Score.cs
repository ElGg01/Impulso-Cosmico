using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private List<AudioClip> scoresSounds = new();
    private int randomIndex;

    private void OnTriggerEnter2D()
    {
        if (!GameManager.Instance.isGameOver)
        {
            GameManager.Instance.IncreaseScore();
            randomIndex = Random.Range(0, scoresSounds.Count);
            SoundController.Instance.EjecutarSonido(scoresSounds[randomIndex]);
        }
    }
}