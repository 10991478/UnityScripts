using UnityEngine;
using UnityEngine.UI;

public class IntSliderScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] IntData intObj;

    public void UpdateValue()
    {
        slider.value = intObj.value;
    }

    public void UpdateMax()
    {
        slider.maxValue = intObj.upperBound;
    }
}
