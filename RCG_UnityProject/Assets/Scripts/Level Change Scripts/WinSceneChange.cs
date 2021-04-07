using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneChange : MonoBehaviour
{
    public int levelNumber;
    public float waitTime;
    public GameObject playerController;

    private bool toggleWin;
    private GameObject winToggle;
    private Animator playerAnimator;
    private Rigidbody2D rigidBody;
    private CharacterInputs CharacterInputs;
    private Animator gemAnimator;

    private void Start()
    {
        winToggle = this.transform.GetChild(0).gameObject;
        gemAnimator = this.transform.GetChild(1).GetComponent<Animator>();
        CharacterInputs = playerController.GetComponent<CharacterInputs>();
        rigidBody = playerController.GetComponent<Rigidbody2D>();
        playerAnimator = playerController.GetComponent<Animator>();
    }

    public void WinToggle()
    {
        toggleWin = true;
        LevelWin();
    }

    public void LevelWin()
    {
        if (toggleWin == true)
        {
            gemAnimator.SetTrigger("Win");
            winToggle.SetActive(true);
            CharacterInputs.canMove = false;
            CharacterInputs.enabled = false;
            rigidBody.velocity = new Vector2(0, 0);
            playerAnimator.SetTrigger("Win");
            Invoke("ChangeScene", waitTime);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: levelNumber);
    }
}
