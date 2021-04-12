using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class DisappearingPlatfroms : MonoBehaviour
{
    private SpriteRenderer sprite;

    public float disappearTimer;
    public float reappearTimer;

    public float respawnDelay;

    private Color newColor;
    private Color oldColor;
    private bool isFading;
    private bool isReappearing;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        oldColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        newColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

    }

    private void Update()
    {

        if (sprite.color == newColor)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            isFading = false;
            Invoke("Reappear", respawnDelay );
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
            isReappearing = false;
        }

        if (isFading)
            sprite.color = Color.Lerp(oldColor, newColor, Mathf.Lerp(0, 1, disappearTimer));

        if (isReappearing)
            sprite.color = Color.Lerp(newColor, oldColor, Mathf.Lerp(0, 1, disappearTimer));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFading = true;
    }

    void Reappear()
    {
        isReappearing = true;
    }

}
