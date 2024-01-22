using UnityEngine;
using UnityEngine.Events;

public class BasicCollisionDetectionBehavior : MonoBehaviour
{
    [SerializeField] private UnityEvent collisionEvent;

    private void OnCollisionEnter(Collision other) {
        collisionEvent.Invoke();
    }

    public void DestroySelf(){
        Destroy(gameObject);
    }
}
