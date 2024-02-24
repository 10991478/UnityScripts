using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Collider coll;
    [SerializeField] private GameObject player;
    private AudioSource playerAudio;
    public AudioClip jumpSound;

    private float horizontalInput;
    [SerializeField] private float speed, jumpHeight;
    [SerializeField] private FloatData speedMultiplier;
    private float travelState = 1.0f;

    private float currentVerticalVelocity, previousVerticalVelocity;
    [SerializeField] private UnityEvent startToFallEvent, landEvent;

    [SerializeField] private BoolData gameOver;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        playerAudio = GetComponent<AudioSource>();
        currentVerticalVelocity = 0;
    }

    void Update()
    {
        if (!gameOver.value){
            //horizontal movement controls
            horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                rb.velocity = new Vector3(horizontalInput * speed * speedMultiplier.value * travelState, rb.velocity.y, 0);
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
        }
    }

    private void FixedUpdate() {
        previousVerticalVelocity = currentVerticalVelocity;
            currentVerticalVelocity = rb.velocity.y;

            if (currentVerticalVelocity < 0 && previousVerticalVelocity >= 0){
                startToFallEvent.Invoke();
                Debug.Log("Falling");
            }

            if (currentVerticalVelocity == 0 && previousVerticalVelocity < 0){
                if (Grounded()) landEvent.Invoke();
                Debug.Log("Landed");
            }
    }

    public void Jump(float height)
    {
        if (Grounded()){
            JumpSound(0.5f);
            rb.velocity = new Vector3(rb.velocity.x, height, 0);
        }
    }

    public void Jump(){
        if (Grounded()){
            JumpSound(0.5f);
            rb.velocity = new Vector3(rb.velocity.x, jumpHeight, 0);
        }
    }

    public void JumpSound(float volume){
        playerAudio.PlayOneShot(jumpSound, volume);
    }


//Got this function from https://forum.unity.com/threads/boxcasting-to-check-grounded.618031/
    protected bool Grounded() {
        Vector3 boxCenter = coll.bounds.center;
        Vector3 halfExtents = coll.bounds.extents*0.9f;
 
        halfExtents.y = .025f;
        float maxDistance = coll.bounds.extents.y;
 
        return Physics.BoxCast(boxCenter, halfExtents, Vector3.down, transform.rotation, maxDistance);
    }

    public void DeactivatePhysics(){
        rb.isKinematic = true;
        coll.enabled = false;
    }

    public void SetTravelState(float num){
        travelState = num;
    }
}
