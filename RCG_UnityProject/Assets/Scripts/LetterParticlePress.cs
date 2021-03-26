using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LetterParticlePress : MonoBehaviour
{
    public Transform instantiateObject;
    public CharControl character;

    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    private String fileName;

    void Update()
    {
        if (Input.anyKeyDown && character.canMove == true)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    //Debug.Log("KeyCode down: " + keyCode);
                    fileName = keyCode + "-LetterParticle";
                    UnityEngine.Object loadedObject = Resources.Load("LetterPrefabs/" + fileName);
                    string stringToCheck = fileName;
                    string[] stringArray = { "A-LetterParticle", "B-LetterParticle", "C-LetterParticle", "D-LetterParticle", "E-LetterParticle", "F-LetterParticle", "G-LetterParticle", "H-LetterParticle", "I-LetterParticle", "J-LetterParticle", "K-LetterParticle", "L-LetterParticle", "M-LetterParticle", "N-LetterParticle", "O-LetterParticle", "P-LetterParticle", "Q-LetterParticle", "R-LetterParticle", "S-LetterParticle", "T-LetterParticle", "U-LetterParticle", "V-LetterParticle", "W-LetterParticle", "X-LetterParticle", "Y-LetterParticle", "Z-LetterParticle", "Space-LetterParticle"};
                    foreach (string x in stringArray)
                    {
                        if (stringToCheck.Contains(x))
                        {
                            Instantiate((GameObject)loadedObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 180, 0), instantiateObject);
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
