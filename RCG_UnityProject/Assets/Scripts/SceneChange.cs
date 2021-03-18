using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    public int num;
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneBuildIndex:num);
    }
}
