using UnityEngine;
using TMPro;

public class IntNumberScript : MonoBehaviour
{
    [SerializeField] private IntData intObj;
    [SerializeField] private TextMeshProUGUI textObj;
    [SerializeField] private string preText, postText;
    private int currentIntValue = 0;

    public void UpdateValue()
    {
        textObj.text = preText + intObj.value.ToString() + postText;
        currentIntValue = intObj.value;
    }

    public void UpdateValueIfHigher()
    {
        if (intObj.value > currentIntValue)
        {
            UpdateValue();
        }
    }
}
