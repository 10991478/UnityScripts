using UnityEngine;
using UnityEngine.UI;

public class IntSliderScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] IntData intObj;
    [SerializeField] FloatData floatObj;

    public void UpdateValue()
    {
        slider.value = intObj.value;
    }

    public void UpdateValueFloat()
    {
        slider.value = floatObj.value;
    }

    public void UpdateMax()
    {
        slider.maxValue = intObj.upperBound;
    }
}
