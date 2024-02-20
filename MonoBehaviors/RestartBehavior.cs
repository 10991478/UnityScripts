using UnityEngine;
using UnityEngine.Events;

public class RestartBehavior : MonoBehaviour
{
    public UnityEvent restartEvent;

    public void RestartGame()
    {
        restartEvent.Invoke();
    }
}