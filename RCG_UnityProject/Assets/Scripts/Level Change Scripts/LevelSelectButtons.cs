using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectButtons : MonoBehaviour
{
    public LevelScriptableObject Levels;

    public Button Level1;
    public Button Level2;
    public Button Level3;

    // Start is called before the first frame update
    void Start()
    {
        Level1.interactable = false;
        Level2.interactable = false;
        Level3.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Levels.level1 == true)
        {
            Level1.interactable = true;
        }
        else
        {
            Level1.interactable = false;
        }

        if (Levels.level2 == true)
        {
            Level2.interactable = true;
        }
        else
        {
            Level2.interactable = false;
        }

        if (Levels.level3 == true)
        {
            Level3.interactable = true;
        }
        else
        {
            Level3.interactable = false;
        }
    }
}
