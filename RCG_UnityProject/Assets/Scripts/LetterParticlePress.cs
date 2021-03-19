using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LetterParticlePress : MonoBehaviour
{
    public Transform instantiateObject;
    private Vector3 instantiatePoint;

    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    private String fileName;

    private GameObject instance;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    Debug.Log("KeyCode down: " + keyCode);
                    fileName = keyCode + "-LetterParticle";
                    UnityEngine.Object loadedObject = Resources.Load("LetterPrefabs/" + fileName);
                    instance = Instantiate((GameObject)loadedObject, instantiatePoint, Quaternion.Euler(0, 180, 0));
                    break;
                }
            }
        }
    }
}
