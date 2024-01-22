using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBehavior : MonoBehaviour
{
    private Collider coll;
    private Rigidbody rb;
    public float gravityScale = -10f;
    public float velocityCap = -100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    void Update()
    {
        if (!Grounded() && rb.velocity.y > velocityCap)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + gravityScale * Time.deltaTime, rb.velocity.z);
            if (rb.velocity.y <= velocityCap) rb.velocity = new Vector3(rb.velocity.x, velocityCap, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }

    protected bool Grounded() //Got this code from https://forum.unity.com/threads/boxcasting-to-check-grounded.618031/
{
        Vector3 boxCenter = coll.bounds.center;
        Vector3 halfExtents = coll.bounds.extents;
 
        halfExtents.y = .025f;
        float maxDistance = coll.bounds.extents.y;
 
        return Physics.BoxCast(boxCenter, halfExtents, Vector3.down, transform.rotation, maxDistance);
    }
}
