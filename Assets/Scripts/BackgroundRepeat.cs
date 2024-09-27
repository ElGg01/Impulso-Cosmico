using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private float spriteWidth;

    void Start()
    {
        BoxCollider2D backgroundCollider =  gameObject.GetComponent<BoxCollider2D>();
        spriteWidth = backgroundCollider.size.x * 6.4f;
    }

    void Update()
    {
        if(transform.position.x < -spriteWidth)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.Translate(new Vector3(2 * spriteWidth, 0f, 0f));
    }
}