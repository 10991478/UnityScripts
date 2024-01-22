using UnityEngine;
using UnityEngine.Events;

public class LockedDoorBehavior : MonoBehaviour
{
    [SerializeField] private UnityEvent unlockEvent;
    [SerializeField] private int numberOfKeysRequired;
    [SerializeField] private IntData playerKeys;
    private void OnCollisionEnter(Collision other) {
        if (playerKeys.value >= numberOfKeysRequired){
            playerKeys.addValue(-numberOfKeysRequired);
            unlockEvent.Invoke();
        }
    }

    public void DestroySelf(){
        Destroy(gameObject);
    }
}
