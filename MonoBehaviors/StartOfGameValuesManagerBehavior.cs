using UnityEngine;
using UnityEngine.Events;

public class StartOfGameValuesManagerBehavior : MonoBehaviour
{
    [SerializeField] private UnityEvent awakeEvent, applicationQuitEvent;
    void Awake()
    {
        InvokeAwakeEvents();
    }

    private void OnApplicationQuit()
    {
        InvokeAppQuitEvents();
    }

    public void InvokeAwakeEvents()
    {
        awakeEvent.Invoke();
    }

    public void InvokeAppQuitEvents()
    {
        applicationQuitEvent.Invoke();
    }
}
