using UnityEngine;
using UnityEngine.UI;

public class CurrentAmmoDisplay : MonoBehaviour
{
    [SerializeField] private RectTransform[] ammoImages;
    [SerializeField] private IntData currentAmmoType;
    [SerializeField] private Vector2 smallScale, largeScale;
    private Vector2[] initialSizes;

    public void Awake()
    {
        initialSizes = new Vector2[ammoImages.Length];

        for (int i = 0; i < ammoImages.Length; i++)
        {
            initialSizes[i] = new Vector2(ammoImages[i].rect.width, ammoImages[i].rect.height);
        }
    }

    public void UpdateSizes()
    {
        for (int i = 0; i < ammoImages.Length; i++)
        {
            ammoImages[i].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialSizes[i].x * smallScale.x);
            ammoImages[i].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, initialSizes[i].y * smallScale.y);
        }
        ammoImages[currentAmmoType.value].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialSizes[currentAmmoType.value].x * largeScale.x);
        ammoImages[currentAmmoType.value].SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, initialSizes[currentAmmoType.value].y * largeScale.y);
    }
}
