using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllerTopDown : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    [SerializeField] private float speed;
    [SerializeField] private FloatData speedMultiplier;
    [SerializeField] private Vector3Data spawnPoint;
    private Vector3 targetPosition;

    void Update()
    {

        //MOVEMENT CONTROLS

        horizontalInput = 0;
        verticalInput = 0;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }

        targetPosition = transform.position;
        targetPosition.x += horizontalInput * speed * speedMultiplier.value * Time.deltaTime;
        targetPosition.z += verticalInput * speed * speedMultiplier.value * Time.deltaTime;

        transform.position = targetPosition;
    }

    public void GoToSpawnPoint()
    {
        transform.position = spawnPoint.GetValue();
    }
}
