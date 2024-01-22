using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DisplayIntData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private IntData intData;
    [SerializeField] private string preText;
    [SerializeField] private UnityEvent startEvent;

    public void UpdateText(){
        textMesh.text = preText + intData.value;
    }

    private void Start(){
        startEvent.Invoke();
    }
}