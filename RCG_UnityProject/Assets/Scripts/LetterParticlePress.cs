using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LetterParticlePress : MonoBehaviour
{
    public Transform instantiateObject;

    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    private String fileName;

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
                    Instantiate((GameObject)loadedObject, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.Euler(0, 180, 0), instantiateObject);
                    break;
                }
            }
        }
    }
}
