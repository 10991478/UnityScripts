using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFollowPlayerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject target;
    public float stopDistance = 2;
    public float walkRange = 5;
    public float runRange = 10;
    private float distancex, distancey;
    private Rigidbody rb;
    private Collider coll;
    [SerializeField] private float zOffset, walkSpeed, runSpeed, jumpHeight;
    [SerializeField] private CoordinateArray playerJumpCoordinates;

    private bool outOfRange = false;

    private void Awake(){
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z + zOffset);


        float direction = 1;
        float targetXPosition = target.transform.position.x;
        float distancex = targetXPosition - transform.position.x;
        if (distancex < 0) direction = -1;
        distancex = Mathf.Abs(distancex);

        if (!outOfRange && distancex > walkRange) outOfRange = true;
        else if (distancex < stopDistance) outOfRange = false;
        
        if (outOfRange){
            if (distancex >= runRange) rb.velocity = new Vector3(runSpeed * direction, rb.velocity.y, 0);
            else rb.velocity = new Vector3(walkSpeed * direction, rb.velocity.y, 0);
        }
        else {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        if (playerJumpCoordinates.WithinAnyMarginsX(transform.position.x)){
            Jump();
        }
    }

    public void Jump(){
        if (Grounded()){
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, 0);
        }
    }


//Got this function from https://forum.unity.com/threads/boxcasting-to-check-grounded.618031/
    protected bool Grounded() {
        Vector3 boxCenter = coll.bounds.center;
        Vector3 halfExtents = coll.bounds.extents*0.9f;
 
        halfExtents.y = .025f;
        float maxDistance = coll.bounds.extents.y;
 
        return Physics.BoxCast(boxCenter, halfExtents, Vector3.down, transform.rotation, maxDistance);
    }
}