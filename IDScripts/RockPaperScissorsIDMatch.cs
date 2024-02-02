using UnityEngine;
using UnityEngine.Events;

public class RockPaperScissorsIDMatch : MonoBehaviour
{
    [SerializeField] private ID selfID, downID, upID;

    [SerializeField] private UnityEvent IDMatchEvent, IDLoseEvent, IDWinEvent;
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<IDContainer>().id == selfID){
            IDMatchEvent.Invoke();
        }
        else if(other.GetComponent<IDContainer>().id == downID){
            IDWinEvent.Invoke();
        }
        else if(other.GetComponent<IDContainer>().id == upID){
            IDLoseEvent.Invoke();
        }
    }
}
