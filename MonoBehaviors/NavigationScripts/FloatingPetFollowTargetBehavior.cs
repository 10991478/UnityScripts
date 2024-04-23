using UnityEngine;

public class FloatingPetFollowTargetBehavior : MonoBehaviour
{
    [SerializeField] private Vector3Data targetPosition;
    [SerializeField] private FloatData speed, accuracy, followDistance;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float distanceSpeedModifier = 0, speedModifierWithinFollowDistance = 0.1f;


    void Update()
    {
        SetVelocity();
    }

    public void SetVelocity()
    {
        Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 targetPos = new Vector3(targetPosition.GetValue().x, 0, targetPosition.GetValue().z);
        float distance = Vector3.Magnitude(targetPos - currentPos);
        Vector3 towardsVector = Vector3.Normalize(targetPos - currentPos) * speed.value;
        if (distance < followDistance.value)
        {
            towardsVector *= speedModifierWithinFollowDistance;
        }
        Vector3 velocityVector = new Vector3(Mathf.Lerp(rb.velocity.x, towardsVector.x, accuracy.value), 0, Mathf.Lerp(rb.velocity.z, towardsVector.z, accuracy.value));
        rb.velocity = velocityVector * (1 + distance * distanceSpeedModifier / 100);
    }
}
