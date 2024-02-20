using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantlyMoveInDirection : MonoBehaviour
{
    [SerializeField] private Vector3 moveVector;
    [SerializeField] private float speedMultiplier;
    void Update()
    {
        transform.position += moveVector * speedMultiplier * Time.deltaTime;
    }
}