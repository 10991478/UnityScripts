using UnityEngine;
using UnityEngine.Events;

public class StartOfGameValuesManagerBehavior : MonoBehaviour
{
    [SerializeField] private UnityEvent awakeEvent;
    void Awake()
    {
        InvokeAwakeEvents();
    }

    public void InvokeAwakeEvents()
    {
        awakeEvent.Invoke();
    }
}
