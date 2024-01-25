using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MonoEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent awakeEvent, startEvent, onEnableEvent;
    [SerializeField] private float holdTime;
    

    private void Awake()
    {
        awakeEvent.Invoke();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(holdTime);
        startEvent.Invoke();
    }

    private void OnEnable() {
        onEnableEvent.Invoke();
    }
}
