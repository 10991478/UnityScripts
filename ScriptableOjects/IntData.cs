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

    public UnityEvent updateValueEvent, updateMaxEvent, updateMinEvent, atMinEvent, atMaxEvent, belowMinEvent, aboveMaxEvent;

    public void SetValue(int newVal){
        value = newVal;
        updateValueEvent.Invoke();
    }

    public void AddValue(int addVal){
        value += addVal;
        updateValueEvent.Invoke();
    }

    public void IncrementValue(){
        value++;
        updateValueEvent.Invoke();
    }

    public void DecrementtValue()
    {
        value--;
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


    /// <summary>
    /// Runs atMinEvent, belowMinEvent, atMaxEvent, and aboveMaxEvent if respective existing bounds are met or exceeded
    /// </summary>
    public void CheckBounds()
    {
        if (hasLowerBound && value == lowerBound) atMinEvent.Invoke();
        else if (hasLowerBound && value < lowerBound) belowMinEvent.Invoke();
        else if (hasUpperBound && value == upperBound) atMaxEvent.Invoke();
        else if (hasUpperBound && value > upperBound) aboveMaxEvent.Invoke();
    }


    /// <summary>
    /// Evaluates whether a given value exceeds existing upper or lower bounds
    /// </summary>
    /// <param name="addVal"></param>
    /// <returns> returns true if added value exceeds existing bounds, returns false if not </returns>
    public bool AddedValueExceedsBounds(int addVal)
    {
        int sum = value + addVal;
        if (hasLowerBound && sum < lowerBound) return true;
        else if (hasUpperBound && sum > upperBound) return true;
        else return false;
    }

    /// <summary>
    /// Evaluates whether a given value exceeds existing lower bound
    /// </summary>
    /// <param name="addVal"></param>
    /// <returns> returns true if added value exceeds existing lower bound, returns false if not </returns>
    public bool AddedValueExceedsLowerBound(int addVal)
    {
        int sum = value + addVal;
        if (hasLowerBound && sum < lowerBound) return true;
        else return false;
    }

    /// <summary>
    /// Evaluates whether a given value exceeds existing upper bound
    /// </summary>
    /// <param name="addVal"></param>
    /// <returns> returns true if added value exceeds existing upper bound, returns false if not </returns>
    public bool AddedValueExceedsUpperBound(int addVal)
    {
        int sum = value + addVal;
        if (hasUpperBound && sum > upperBound) return true;
        else return false;
    }
}
