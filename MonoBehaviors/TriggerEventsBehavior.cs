using UnityEngine;
using UnityEngine.Events;

public class TriggerEventsBehavior : MonoBehaviour
{
    [SerializeField] private UnityEvent triggerEvent;
    private void OnTriggerEnter(Collider other) {
        triggerEvent.Invoke();
    }
}
