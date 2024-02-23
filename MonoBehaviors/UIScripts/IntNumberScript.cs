using UnityEngine;
using TMPro;

public class IntNumberScript : MonoBehaviour
{
    [SerializeField] private IntData intObj;
    [SerializeField] private TextMeshProUGUI textObj;
    [SerializeField] private string preText, postText;

    public void UpdateValue()
    {
        textObj.text = preText + intObj.value.ToString() + postText;
    }
}
