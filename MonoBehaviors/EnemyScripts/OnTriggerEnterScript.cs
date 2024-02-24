using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterScript : MonoBehaviour
{
    [SerializeField] private UnityEvent onCollisionEvent, timedEvent;
    [SerializeField] private float seconds;
    private WaitForSeconds wfsObj;

    private void Awake()
    {
        wfsObj = new WaitForSeconds(seconds);
    }
    private IEnumerator OnTriggerEnter(Collider collider)
    {
        onCollisionEvent.Invoke();
        yield return wfsObj;
        timedEvent.Invoke();
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