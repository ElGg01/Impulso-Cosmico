using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida = 0.5f;

    private void Start()
    {
        Invoke("DestruirObjeto", tiempoDeVida);
    }

    private void DestruirObjeto()
    {
        Destroy(gameObject);
    }
}