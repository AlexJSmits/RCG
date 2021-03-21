using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshPro Text;
    public Animator animator;

    [TextArea(3, 10)]
    public string textToShow;

    public float duration;

    public void DialoguePopUp()
    {
        animator.SetBool("textOpen", true);
        Text.text = textToShow;
        Invoke("DialoguePopDown", duration);
    }

    void DialoguePopDown()
    {
        animator.SetBool("textOpen", false);
        Invoke("DialogueHide", 0.5f);
    }

    void DialogueHide()
    {
        animator.SetTrigger("dialogueHasFinished");
    }

}
