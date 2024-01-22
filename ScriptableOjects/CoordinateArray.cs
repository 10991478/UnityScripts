using UnityEngine;

[CreateAssetMenu]

public class CoordinateArray : ScriptableObject
{
    [SerializeField] private int numberOfCoordinates = 1;
    [SerializeField] private Vector3 distanceMargin = new Vector3(1, 1, 1);
    private CoordinateData[] coordinates = new CoordinateData[1];

    void OnEnable()
    {
        coordinates = new CoordinateData[numberOfCoordinates];
        for (int i = 0; i < coordinates.Length; i++){
            coordinates[i] = new CoordinateData(distanceMargin);
        }
    }

    public void SetNumOfCoords(int num){
        coordinates = new CoordinateData[num];
        for (int i = 0; i < coordinates.Length; i++){
            coordinates[i] = new CoordinateData(distanceMargin);
        }
    }

    public Vector3[] GetCoordinateVectors(){
        Vector3[] returnArray = new Vector3[coordinates.Length];
        for (int i = 0; i < coordinates.Length; i++){
            returnArray[i] = coordinates[i].GetVector();
        }
        return returnArray;
    }

    public bool WithinAnyMargins(Vector3 inputVector){
        bool anyMargins = false;
        for (int i = 0; i < coordinates.Length; i++){
            if (coordinates[i].WithinMargin(inputVector) && coordinates[i].IsValid()){
                anyMargins = true;
                coordinates[i].SetValid(false);
            }
        }
        return anyMargins;
    }
    public bool WithinAnyMarginsX(float xValue){
        bool anyMargins = false;
        for (int i = 0; i < coordinates.Length; i++){
            if (coordinates[i].WithinMarginX(xValue) && coordinates[i].IsValid()){
                anyMargins = true;
                coordinates[i].SetValid(false);
            }
        }
        return anyMargins;
    }
    public bool WithinAnyMarginsY(float yValue){
        bool anyMargins = false;
        for (int i = 0; i < coordinates.Length; i++){
            if (coordinates[i].WithinMarginX(yValue) && coordinates[i].IsValid()){
                anyMargins = true;
                coordinates[i].SetValid(false);
            }
        }
        return anyMargins;
    }
    public bool WithinAnyMarginsZ(float zValue){
        bool anyMargins = false;
        for (int i = 0; i < coordinates.Length; i++){
            if (coordinates[i].WithinMarginX(zValue) && coordinates[i].IsValid()){
                anyMargins = true;
                coordinates[i].SetValid(false);
            }
        }
        return anyMargins;
    }

    public void SetNewCoordinate(Vector3 inputVector){
        bool anyInvalids = false;
        int i = 0;
        while (!anyInvalids && i < coordinates.Length){
            if (coordinates[i].IsValid() == false){
                coordinates[i].SetVector(inputVector);
                coordinates[i].SetValid(true);
                anyInvalids = true;
            }
            i++;
        }
        if (!anyInvalids){
            coordinates[0].SetVector(inputVector);
            coordinates[0].SetValid(true);
        }
    }
}