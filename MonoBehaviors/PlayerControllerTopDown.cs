using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllerTopDown : MonoBehaviour
{
    private Rigidbody rb;

    private float horizontalInput, verticalInput;
    [SerializeField] private float speed;
    [SerializeField] private FloatData speedMultiplier, shotCooldown;
    private float travelState = 1.0f;
    private float timeSinceLastShot, shootingDirection = 0;
    private int currentAmmoType = 0;
    [SerializeField] private GameObject[] ammoObjects;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        timeSinceLastShot = Time.time;
    }

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



        //SHOOTING CONTROLS

        if (Input.GetKeyDown(KeyCode.UpArrow)) shootingDirection = 1f;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) shootingDirection = 2f;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) shootingDirection = 3f;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) shootingDirection = 4f;
        else if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow)) shootingDirection = 0f;

        if (shootingDirection != 0f && Time.time - timeSinceLastShot >= shotCooldown.value)
        {
            Shoot(shootingDirection);
            timeSinceLastShot = Time.time;
        }

        //SWITCHING AMMO TYPE
        if (Input.GetKeyDown(KeyCode.E)) currentAmmoType += 1;
        if (Input.GetKeyDown(KeyCode.Q)) currentAmmoType -= 1;

        if (currentAmmoType < 0) currentAmmoType = ammoObjects.Length - 1;
        else if (currentAmmoType >= ammoObjects.Length) currentAmmoType = 0;
    }

    public void SetTravelState(float ts)
    {
        travelState = ts;
    }

    public void Shoot(float direction)
    {
        Instantiate(ammoObjects[currentAmmoType], transform.position, transform.rotation * Quaternion.Euler(0, 90*(shootingDirection-1), 0));

    }
}
