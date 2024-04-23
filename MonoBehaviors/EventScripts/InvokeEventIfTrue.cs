using UnityEngine;
using UnityEngine.Events;

public class InvokeEventIfTrue : MonoBehaviour
{
    [SerializeField] private BoolData boolObj;
    [SerializeField] private UnityEvent onTrueEvent, onFalseEvent;

    public void EvaluateTrue()
    {
        if (boolObj.value) onTrueEvent.Invoke();
    }

    public void EvaluateFalse()
    {
        if (!boolObj.value) onFalseEvent.Invoke();
    }

    public void EvaluateBoth()
    {
        EvaluateTrue();
        EvaluateFalse();
    }
}
