using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxRepeat : MonoBehaviour
{
    private float spriteWidth = 2.72f * 6.4f;
    [SerializeField] private int min  = -4;
    [SerializeField] private int max = 2;
    private int numeroAleatorio;

    System.Random random = new System.Random();

    void Start()
    {
        BoxCollider2D backgroundCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (transform.position.x < -spriteWidth)
        {
            numeroAleatorio = random.Next(min, max + 1);
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.position = Vector3.zero;
        transform.Translate(new Vector3(2 * spriteWidth, numeroAleatorio, 0f));
    }
}
