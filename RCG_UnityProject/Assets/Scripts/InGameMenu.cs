using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject menuToggle;
    public CharacterInputs characterInputs;

    private bool menuBool = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuBool == false)
        {
            menuBool = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuBool == true)
        {
            menuBool = false;
            if (characterInputs.startDelay <= 0.0f)
                characterInputs.canMove = true;
        }

        if (menuBool == false)
        {
            Time.timeScale = 1.0f;
            menuToggle.SetActive(false);
        }
        
        if (menuBool == true)
        {
            characterInputs.canMove = false;
            Time.timeScale = 0.0f;
            menuToggle.SetActive(true);
        }
    }

    public void Resume()
    {
        menuBool = false;
        if (characterInputs.startDelay <= 0.0f)
            characterInputs.canMove = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
