using UnityEngine;
using UnityEngine.UI;

public class CurrentAmmoDisplay : MonoBehaviour
{
    [SerializeField] private Image[] ammoImages;
    [SerializeField] private IntData currentAmmoType;
    [SerializeField] private Vector2 smallSize, largeSize;

    public void UpdateSizes()
    {
        foreach (Image img in ammoImages)
        {
            img.rectTransform.sizeDelta = smallSize;
        }
        ammoImages[currentAmmoType.value].rectTransform.sizeDelta = largeSize;
    }
}
