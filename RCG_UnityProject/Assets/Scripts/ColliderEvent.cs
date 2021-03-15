using UnityEngine;
using UnityEngine.Events;

public class ColliderEvent : MonoBehaviour
{
    public UnityEvent EnterEvent;
    public UnityEvent ExitEvent;

    void OnTriggerEnter2D()
    {
         EnterEvent.Invoke();
    }

    void OnTriggerExit2D()
    {
         ExitEvent.Invoke();
    }
}
