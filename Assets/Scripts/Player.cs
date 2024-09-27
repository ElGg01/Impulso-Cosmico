using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float upForce;
    [SerializeField] private float rotationVelocity;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameObject flame;
    private Renderer flameRenderer;
    private bool showFlame;

    private bool hasJumped = false;

    private Rigidbody2D playerRb;
    private bool isDead;

    [SerializeField] private GameObject explosionEffect;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        flameRenderer = flame.GetComponent<Renderer>();
    }

    void Update()
    {
        float anguloActual = transform.rotation.eulerAngles.z;

        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0)) && !isDead && !showFlame && !hasJumped)
        {
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(Vector2.up * upForce);

            showFlame = true;
            hasJumped = true;

            if (anguloActual < 320f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, anguloActual + rotationVelocity * 1.2f);
            }

            SoundController.Instance.EjecutarSonido(jumpSound);

        } else if (!isDead)
        {
            if (anguloActual > 220f)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, anguloActual - (rotationVelocity) * Time.deltaTime * 1.8f);
            }
        }

        if (showFlame)
        {
            StartCoroutine(HideFlameAfterDelay(0.1f));
        }

        flameRenderer.enabled = showFlame;
    }

    private void OnCollisionEnter2D()
    {
        isDead = true;
        ShakeMovementCamera.Instance.moveCamera(10f, 10f, 1f);
        SoundController.Instance.EjecutarSonido(deathSound);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        GameManager.Instance.GameOver();
    }

    private IEnumerator HideFlameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        showFlame = false;
    }

    private void LateUpdate()
    {
        if (Input.touchCount == 0)
        {
            hasJumped = false;
        }
    }
}
