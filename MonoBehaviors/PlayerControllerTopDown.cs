using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllerTopDown : MonoBehaviour
{
    private Rigidbody rb;

    private float horizontalInput, verticalInput;
    [SerializeField] private float speed;
    [SerializeField] private FloatData speedMultiplier;
    private float travelState = 1.0f;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //horizontal movement controls
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0)
        {
            rb.velocity = new Vector3(horizontalInput * speed * speedMultiplier.value * travelState, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if (verticalInput != 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, verticalInput * speed * speedMultiplier.value * travelState);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        }
    }

    public void SetTravelState(float ts)
    {
        travelState = ts;
    }
}
