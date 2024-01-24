using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    [SerializeField] private Vector3 value;
    [SerializeField] private bool hasXMax, hasXMin, hasYMax, hasYMin, hasZMax, hasZMin;

    [SerializeField] private float xMax, xMin, yMax, yMin, zMax, zMin;

    public UnityEvent updateValueEvent, atOrBelowMinEvent, atOrAboveMaxEvent;

    public Vector3 GetValue(){
        return value;
    }

    public void SetValue(Vector3 newVal){
        value = newVal;
        updateValueEvent.Invoke();
    }

    public void AddValue(Vector3 addVal){
        value += addVal;
        updateValueEvent.Invoke();
    }

    public Vector3 EvaluateLimits(){
        Vector3 temp = new Vector3(0,0,0);
        if (value.x > xMax && hasXMax)
        {
            temp.x = 1;
        }
        else if (value.x < xMin && hasXMin)
        {
            temp.x = -1;
        }
        if (value.y > yMax && hasYMax)
        {
            temp.y = 1;
        }
        else if (value.y < yMin && hasYMin)
        {
            temp.y = -1;
        }
        if (value.z > zMax && hasZMax)
        {
            temp.z = 1;
        }
        else if (value.z < zMin && hasZMin)
        {
            temp.z = -1;
        }

        return temp;
    }

    public void HandleLimits()
    {
        if (value.x > xMax && hasXMax)
        {
            value.x = xMax;
            updateValueEvent.Invoke();
            atOrAboveMaxEvent.Invoke();
        }
        else if (value.x < xMin && hasXMin)
        {
            value.x = xMin;
            updateValueEvent.Invoke();
            atOrBelowMinEvent.Invoke();
        }
        if (value.y > yMax && hasYMax)
        {
            value.y = yMax;
            updateValueEvent.Invoke();
            atOrAboveMaxEvent.Invoke();
        }
        else if (value.y < yMin && hasYMin)
        {
            value.y = yMin;
            updateValueEvent.Invoke();
            atOrBelowMinEvent.Invoke();
        }
        if (value.z > zMax && hasZMax)
        {
            value.z = zMax;
            updateValueEvent.Invoke();
            atOrAboveMaxEvent.Invoke();
        }
        else if (value.z < zMin && hasZMin)
        {
            value.z = zMin;
            updateValueEvent.Invoke();
            atOrBelowMinEvent.Invoke();
        }
    }
}
