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
    [SerializeField] private Rigidbody rb;

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

        rb.velocity = Vector3.Normalize(new Vector3(horizontalInput, 0, verticalInput))*speed*speedMultiplier.value;
    }

    public void GoToSpawnPoint()
    {
        transform.position = spawnPoint.GetValue();
    }
}
