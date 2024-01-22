using UnityEngine;
using UnityEngine.Events;

public class StartOfGameValuesManagerBehavior : MonoBehaviour
{
    [SerializeField] private UnityEvent awakeEvent;
    void Awake()
    {
        awakeEvent.Invoke();
    }
}
