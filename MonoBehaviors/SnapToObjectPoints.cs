using UnityEngine;

public class SnapToObjectPoints : MonoBehaviour
{
    [SerializeField] private Transform otherTransform;
    [SerializeField] private int snapScaleX = 1, snapScaleY = 1, snapScaleZ = 1;
    private int posX, otherX, posY, otherY, posZ, otherZ;
    void Update()
    {
        otherX = (otherTransform.position.x >= 0) ? (int)(otherTransform.position.x + 0.5) : (int)(otherTransform.position.x - 0.5);
        posX = otherX - (otherX % snapScaleX);
        otherY = (otherTransform.position.y >= 0) ? (int)(otherTransform.position.y + 0.5) : (int)(otherTransform.position.y - 0.5);
        posY = otherY - (otherY % snapScaleY);
        otherZ = (otherTransform.position.z >= 0) ? (int)(otherTransform.position.z + 0.5) : (int)(otherTransform.position.z - 0.5);
        posZ = otherZ - (otherZ % snapScaleZ);
        transform.position = new Vector3(posX, posY, posZ);
    }
}