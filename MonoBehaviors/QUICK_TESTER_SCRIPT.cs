/*
    !!!!!!!
    !!!!!!!
    THIS SCRIPT IS JUST FOR QUICK TESTING. ANY CODE IN HERE IS
    FULLY TEMPORARY AND WILL DRASTICALLY CHANGE WHENVER NEEDED
    !!!!!!!
    !!!!!!!
*/





using UnityEngine;
using UnityEngine.Events;

public class QUICK_TESTER_SCRIPT : MonoBehaviour
{
    [SerializeField] private UnityEvent pressSpaceEvent;
    [SerializeField] private CoordinateArray playerJumpCoordinates;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)){
            playerJumpCoordinates.SetNewCoordinate(transform.position);
            pressSpaceEvent.Invoke();
        }
    }
}