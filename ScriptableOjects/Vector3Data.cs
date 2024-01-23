using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    [SerializeField] private Vector3 value;
    [SerializeField] private bool xMax, xmin, yMax, yMin, zMax, zMin;

    [SerializeField] private float xMax, xMin, yMax, yMin, zMax, zMin;

    public UnityEvent updateValueEvent, atOrBelowMinEvent, atOrAboveMaxEvent;

    public Vector3 getValue(){
        return value;
    }

    public void setValue(Vector3 newVal){
        value = newVal;
        updateValueEvent.Invoke();
    }

    public void addValue(Vector3 addVal){
        value += addVal;
        updateValueEvent.Invoke();
    }

    public Vector3 evaluateLimits(){
        Vector3 temp = new Vector3(0,0,0);
        if (value.x > xMax || value.x < xMin){
            Vector3.x = 1;
        }
        if (value.y > yMax || value.y < yMin){
            Vector3.y = 1;
        }
        if (value.z > zMax || value.z < zMin){
            Vector3.z = 1;
        }

        return temp;
    }



}
