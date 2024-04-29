using UnityEngine;
using UnityEngine.Events;

public class KeyPressEventHandler : MonoBehaviour
{
    [SerializeField] private KeyCode keyToPress = KeyCode.Space; // Default key is Space
    [SerializeField] bool isConditional = false;
    [SerializeField] BoolData condition;
    [SerializeField] private UnityEvent onPressed, onHold, onRelease;

    void Update()
    {
        if (!isConditional) CheckKeyNoCondition();
        else CheckKeyWithCondition(condition);
    }

    public void CheckKeyNoCondition()
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

    public void CheckKeyWithCondition(BoolData cond)
    {
        if (Input.GetKeyDown(keyToPress) && cond.value == true)
        {
            onPressed.Invoke();
        }
        else if (Input.GetKey(keyToPress) && cond.value == true)
        {
            onHold.Invoke();
        }
        else if (Input.GetKeyUp(keyToPress) && cond.value == true)
        {
            onRelease.Invoke();
        }
    }

    public void DebugLog(string str){Debug.Log(str);}
    
}
