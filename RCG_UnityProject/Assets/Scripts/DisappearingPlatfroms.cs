using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class DisappearingPlatfroms : MonoBehaviour
{
    private SpriteRenderer sprite;

    public float length;
    public float respawnDelay;

    private Color newColor;
    private Color oldColor;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        oldColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        newColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        sprite.color = oldColor;
    }

    private void Update()
    {
        if (sprite.color.a == 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
            GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        oldColor = Color.Lerp(oldColor, newColor, length * Time.deltaTime);
    }

    void Reappear()
    {

    }

}
