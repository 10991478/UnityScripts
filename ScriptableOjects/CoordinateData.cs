using UnityEngine;

[CreateAssetMenu]
public class CoordinateData : ScriptableObject {
    private Vector3 coordinateVector = new Vector3(0,0,0);
    private bool validCoordinate = false;

    [SerializeField] private Vector3 distanceMargin = new Vector3(1,1,1);


    public CoordinateData(Vector3 margin){
        distanceMargin = margin;
    }


//getter methods
    public Vector3 GetVector(){
        return coordinateVector;
    }
    public bool IsValid(){
        return validCoordinate;
    }
    public Vector3 GetMargine(){
        return distanceMargin;
    }


//setter methods
    public void SetVector(Vector3 val){
        coordinateVector = val;
    }
    public void SetValid(bool val){
        validCoordinate = val;
    }
    public void SetMargine(Vector3 margin){
        distanceMargin = margin;
    }


//within margin methods
    public bool WithinMargin(Vector3 inputVector){
        if (Mathf.Abs(inputVector.x - coordinateVector.x) > Mathf.Abs(distanceMargin.x)){
            return false;
        }
        else if (Mathf.Abs(inputVector.y - coordinateVector.y) > Mathf.Abs(distanceMargin.y)){
            return false;
        }
        else if (Mathf.Abs(inputVector.z - coordinateVector.z) > Mathf.Abs(distanceMargin.z)){
            return false;
        }
        else return true;
    }
    public bool WithinMarginX(float xValue){
        if (Mathf.Abs(xValue - coordinateVector.x) > Mathf.Abs(distanceMargin.x)){
            return false;
        }
        else return true;
    }
    public bool WithinMarginY(float yValue){
        if (Mathf.Abs(yValue - coordinateVector.y) > Mathf.Abs(distanceMargin.y)){
            return false;
        }
        else return true;
    }
    public bool WithinMarginZ(float zValue){
        if (Mathf.Abs(zValue - coordinateVector.z) > Mathf.Abs(distanceMargin.z)){
            return false;
        }
        else return true;
    }
}