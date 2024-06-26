/*
    !!!!!!!
    !!!!!!!
    THIS SCRIPT IS JUST FOR QUICK TESTING. ANY CODE IN HERE IS
    FULLY TEMPORARY AND WILL DRASTICALLY CHANGE WHENVER NEEDED
    !!!!!!!
    !!!!!!!
*/





using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

public class QUICK_TESTER_SCRIPT : MonoBehaviour
{
    [SerializeField] private UnityEvent pressSpaceEvent, timerEvent;
    [SerializeField] private CoordinateArray playerJumpCoordinates;
    [SerializeField] private float seconds;
    private WaitForSeconds wfsObj;

    private void Awake()
    {
        wfsObj = new WaitForSeconds(seconds);
    }

    private void Start()
    {
        StartCoroutine(TimerFunction());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            pressSpaceEvent.Invoke();
        }
    }

    private IEnumerator TimerFunction()
    {
        while (true)
        {
            yield return wfsObj;
            timerEvent.Invoke();
        }
    }

    public void PrintMethod(string str)
    {
        Debug.Log(str);
    }

    public void DeletePlayerPreferences(){
        PlayerPrefs.DeleteAll();
    }
}