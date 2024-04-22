using UnityEngine;
using UnityEngine.Events;

public class KeyPressEventHandler : MonoBehaviour
{
    [SerializeField] private KeyCode keyToPress = KeyCode.Space; // Default key is Space
    [SerializeField] private UnityEvent onPressed, onHold, onRelease;

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            onPressed.Invoke();
        }
        else if (Input.GetKey(keyToPress))
        {
            onHold.Invoke();
        }
        else if (Input.GetKeyUp(keyToPress))
        {
            onRelease.Invoke();
        }
    }

    public void DebugLog(string str){Debug.Log(str);}
    
}
