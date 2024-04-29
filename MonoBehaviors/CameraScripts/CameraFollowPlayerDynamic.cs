using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayerDynamic : MonoBehaviour
{
    [SerializeField] private bool followX, followY, followZ;
    [SerializeField] private GameObject target;
    [SerializeField] private float xRange = 15;
    [SerializeField] private float yRange = 8;
    [SerializeField] private float zRange = 15;
    private float distanceX, distanceY, distanceZ;
    private Vector3 newPosition;
    [SerializeField] private Vector3 rangeOffset;

    private void Update()
    {
        newPosition = transform.position;
        distanceX = transform.position.x - target.transform.position.x - rangeOffset.x;
        distanceY = transform.position.y - target.transform.position.y - rangeOffset.y;
        distanceZ = transform.position.z - target.transform.position.z - rangeOffset.z;
        if (Mathf.Abs(distanceX) >= xRange && followX)
        {
            newPosition.x += (Mathf.Abs(distanceX)/distanceX)*xRange - distanceX;
        }
        if (Mathf.Abs(distanceY) >= yRange && followY)
        {
            newPosition.y += (Mathf.Abs(distanceY)/distanceY)*yRange - distanceY;
        }
        if (Mathf.Abs(distanceZ) >= zRange && followZ)
        {
            newPosition.z += (Mathf.Abs(distanceZ)/distanceZ)*zRange - distanceZ;
        }
        transform.position = newPosition;
    }
}