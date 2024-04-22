using UnityEngine;

public class MiniMapBehavior : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Vector3Data targetCoordinates;
    [SerializeField] private float worldXBorder = 100, worldZBorder = 100, mapWidth = 50, mapHeight = 50, xOffset = 0, zOffset = 0;

    private void Update()
    {
        rectTransform.anchoredPosition = new Vector3(targetCoordinates.GetValue().x * (mapWidth / worldXBorder) + xOffset,
            targetCoordinates.GetValue().z * (mapHeight / worldZBorder) + zOffset, 0);
    }
}
