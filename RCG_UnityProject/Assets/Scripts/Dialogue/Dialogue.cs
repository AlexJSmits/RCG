using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshPro text;
    public string textToShow;
    public Animator animator;

    public void DialoguePopUp()
    {
        animator.SetBool("textOpen", true);
        text.text = textToShow;
        Invoke("DialoguePopDown", 6f);
    }

    void DialoguePopDown()
    {
        animator.SetBool("textOpen", false);
    }
}
