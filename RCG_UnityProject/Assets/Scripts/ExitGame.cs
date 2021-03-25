using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitGameTrigger()
    {
        Application.Quit();
        //Debug.Log("Game Quit");
    }
}
