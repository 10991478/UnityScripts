using UnityEngine;
using UnityEngine.Events;

public class BasicGameActionHandler : MonoBehaviour
{
    [SerializeField] private GameAction action;
    [SerializeField] private UnityEvent respondEvent;

    private void OnEnable()
    {
        action.raiseNoArgs += Respond; // Subscribes the Respond method to the GameAction's raiseNoArgs event
    }

    private void Respond()
    {
        respondEvent.Invoke();
    }
}