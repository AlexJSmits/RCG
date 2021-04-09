using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatfroms : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;

    public float respawnDelay;
    

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("Disappear");
        Invoke("Reappear", 7 + respawnDelay);
    }

    void Reappear()
    {
        Debug.Log("Now");
        animator.SetTrigger("Reappear");
    }

}
