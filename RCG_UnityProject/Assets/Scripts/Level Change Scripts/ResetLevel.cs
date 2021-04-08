using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public Animator animator;

    private float countdown;
    private int levelNumber;

    void Awake()
    {
        countdown = 2.15f;
        levelNumber = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            countdown -= Time.deltaTime;
            animator.SetBool("Countdown", true);
        }
        else
        {
            countdown = 2.15f;
            animator.SetBool("Countdown", false);
        } 

        if (countdown <= 0.0f)
        {
            SceneManager.LoadScene(sceneBuildIndex: levelNumber);
        }
    }
}
