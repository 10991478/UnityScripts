using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DetectPlayerCollision : MonoBehaviour
{
    [SerializeField] private int playerLayer;
    [SerializeField] private float secondsBetweenRecurringEvent;
    [SerializeField] UnityEvent instantEvent, recurringEvent;
    private bool continueRecurring = true;
    private WaitForSeconds wfsObj;

    private void Awake()
    {
        wfsObj = new WaitForSeconds(secondsBetweenRecurringEvent);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            continueRecurring = true;
            instantEvent.Invoke();
            StartCoroutine(RecurringEvent());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            continueRecurring = false;
            StopCoroutine(RecurringEvent());
        }
    }

    private IEnumerator RecurringEvent()
    {
        while (continueRecurring)
        {
            recurringEvent.Invoke();
            yield return wfsObj;
        }
    }
}
