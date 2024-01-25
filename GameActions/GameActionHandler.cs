using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameAction action; // Reference to a GameAction instance
    public UnityEvent startEvent, respondEvent, respondLateEvent, runInAnimatorEvent;
    public float holdTime = 0.1f; // Duration of the hold time
    private WaitForSeconds waitObj; // WaitForSeconds instance for delayed execution

    private void Start()
    {
        startEvent.Invoke(); // Invokes the start event
    }

    private void OnEnable()
    {
        waitObj = new WaitForSeconds(holdTime); // Initializes WaitForSeconds object
        action.raiseNoArgs += Respond; // Subscribes the Respond method to the GameAction's raiseNoArgs event
    }

    private void Respond()
    {
        respondEvent.Invoke(); // Invokes the respond event
        StartCoroutine(RespondLate()); // Starts a coroutine for delayed event invocation
    }

    private IEnumerator RespondLate()
    {
        yield return waitObj; // Delays execution
        respondLateEvent.Invoke(); // Invokes the delayed respond event
    }
}