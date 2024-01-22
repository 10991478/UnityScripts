using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]

public class BoolData : ScriptableObject
{
    public bool value;

    [SerializeField] private UnityEvent onTrueEvent, onFalseEvent;

    public void setVal(bool val){
        value = val;

        if (value) onTrueEvent.Invoke();
        else onFalseEvent.Invoke();
    }


}
