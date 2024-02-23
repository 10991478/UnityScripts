using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ExecuteAfterStart : MonoBehaviour
{
    [SerializeField] private float seconds;
    [SerializeField] private UnityEvent executeEvent;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(seconds);
        executeEvent.Invoke();
    }


    public void KillYourself()
    {
        Destroy(gameObject);
    }

    public void KillYourParent()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}