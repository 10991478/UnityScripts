using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;
    public bool hasUpperBound;
    public bool hasLowerBound;
    public int lowerBound;
    public int upperBound;

    public UnityEvent updateValueEvent, updateMaxEvent, updateMinEvent, atOrBelowMinEvent, atOrAboveMaxEvent;

    public void SetValue(int newVal){
        value = newVal;
        updateValueEvent.Invoke();
    }

    public void AddValue(int addVal){
        value += addVal;
        updateValueEvent.Invoke();

        if (hasLowerBound && value <= lowerBound) atOrBelowMinEvent.Invoke();
        if (hasUpperBound && value >= upperBound) atOrAboveMaxEvent.Invoke();
    }

    public void IncrementValue(){
        AddValue(1);
        updateValueEvent.Invoke();
    }

    public void SetToMax()
    {
        value = upperBound;
        updateValueEvent.Invoke();
    }

    public void SetToMin()
    {
        value = lowerBound;
        updateValueEvent.Invoke();
    }

    public void SetMaxValue(int val)
    {
        upperBound = val;
        updateMaxEvent.Invoke();
    }

    public void SetMinValue(int val)
    {
        lowerBound = val;
        updateMinEvent.Invoke();
    }

    public void AddMaxValue(int val)
    {
        upperBound += val;
        updateMaxEvent.Invoke();
    }

    public void AddMinValue(int val)
    {
        lowerBound += val;
        updateMinEvent.Invoke();
    }
}
