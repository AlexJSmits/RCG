using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabTime : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }
}
