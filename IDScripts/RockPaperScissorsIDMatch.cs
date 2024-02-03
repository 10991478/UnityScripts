using UnityEngine;
using UnityEngine.Events;

public class RockPaperScissorsIDMatch : MonoBehaviour
{
    [SerializeField] private ID selfID, downID, upID;

    [SerializeField] private UnityEvent IDMatchEvent, IDLoseEvent, IDWinEvent;
    private void OnTriggerEnter(Collider other) {
        var tempObj = other.GetComponent<IDContainer>();
        if (tempObj == null) return;
        else {
            if(tempObj.id == selfID){
                IDMatchEvent.Invoke();
            }
            else if(tempObj.id == downID){
                IDWinEvent.Invoke();
            }
            else if(tempObj.id == upID){
                IDLoseEvent.Invoke();
            }
        }
        
    }


    public void TempMethod(int num){
        if (num == -1){
            Debug.Log("lost");
        }
        if (num == 0){
            Debug.Log("same");
        }
        if (num == 1){
            Debug.Log("won");
        }
    }
}
