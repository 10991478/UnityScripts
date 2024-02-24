using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value;
    public bool hasUpperBound;
    public bool hasLowerBound;
    public float lowerBound; //lower limit for value if hasLowerBound is true
    public float upperBound; //upper limit for value if hasUpperBound is true

    public UnityEvent updateValueEvent, atOrBelowMinEvent, atOrAboveMaxEvent, updateMaxEvent, updateMinEvent;

    public void SetValue(float newVal){
        value = newVal;
        updateValueEvent.Invoke();
    }

    public void RoundValueToPlaces(int places)
    {
        for (int i = 0; i < places; i++)
        {
            value *= 10;
        }

        value = (int)value;

        for (int i = 0; i < places; i++)
        {
            value /= 10;
        }

        updateValueEvent.Invoke();
    }
    
    public void AddValue(float addVal){
        value += addVal;
        updateValueEvent.Invoke();

        if (value <= lowerBound && hasLowerBound) atOrBelowMinEvent.Invoke();
        else if (value >= upperBound && hasUpperBound) atOrAboveMaxEvent.Invoke();
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

    public void SetMaxValue(float val)
    {
        upperBound = val;
        updateMaxEvent.Invoke();
    }

    public void SetMinValue(float val)
    {
        lowerBound = val;
        updateMinEvent.Invoke();
    }

    public void AddMaxValue(float val)
    {
        upperBound += val;
        updateMaxEvent.Invoke();
    }

    public void AddMinValue(float val)
    {
        lowerBound += val;
        updateMinEvent.Invoke();
    }
}
