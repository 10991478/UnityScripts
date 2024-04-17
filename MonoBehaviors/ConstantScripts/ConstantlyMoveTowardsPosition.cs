using UnityEngine;

public class ConstantlyMoveTowardsPosition : MonoBehaviour
{
    [SerializeField] private Vector3Data targetPosition;
    [SerializeField] private FloatData speed, accuracy;
    [SerializeField] private Rigidbody rb;


    void Update()
    {
        Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 targetPos = new Vector3(targetPosition.GetValue().x, 0, targetPosition.GetValue().z);
        Vector3 towardsVector = Vector3.Normalize(targetPos - currentPos) * speed.value;
        rb.velocity = new Vector3(Mathf.Lerp(rb.velocity.x, towardsVector.x, accuracy.value), 0, Mathf.Lerp(rb.velocity.z, towardsVector.z, accuracy.value));
    }
}
