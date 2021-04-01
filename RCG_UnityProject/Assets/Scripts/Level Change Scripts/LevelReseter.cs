using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReseter : MonoBehaviour
{
    public LevelScriptableObject Levels;

    void LevelReset()
    {
        Levels.level1 = false;
        Levels.level2 = false;
        Levels.level3 = false;
    }
}
