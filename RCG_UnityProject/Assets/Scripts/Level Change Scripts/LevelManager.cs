using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelScriptableObject Levels;

    public void LevelReset()
    {
        Levels.level1 = false;
        Levels.level2 = false;
        Levels.level3 = false;
    }

    public void Level1Playable()
    {
        Levels.level1 = true;
    }

    public void Level2Playable()
    {
        Levels.level2 = true;
    }

    public void Level3Playable()
    {
        Levels.level3 = true;
    }
}
