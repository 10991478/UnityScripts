using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public float xRange = 15;
    public float yRange = 8;
    private float distancex, distancey;
    private Vector3 newPosition;
    public Vector3 rangeOffset;

    private void Update()
    {
        newPosition = transform.position;
        distancex = transform.position.x - target.transform.position.x - rangeOffset.x;
        distancey = transform.position.y - target.transform.position.y - rangeOffset.y;
        if (Mathf.Abs(distancex) >= xRange)
        {
            newPosition.x += (Mathf.Abs(distancex)/distancex)*xRange - distancex;
        }
        if (Mathf.Abs(distancey) >= yRange)
        {
            newPosition.y += (Mathf.Abs(distancey)/distancey)*yRange - distancey;
        }
        transform.position = newPosition;
    }
}