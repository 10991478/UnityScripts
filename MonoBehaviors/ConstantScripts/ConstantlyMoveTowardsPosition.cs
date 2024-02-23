using UnityEngine;

public class ConstantlyMoveTowardsPosition : MonoBehaviour
{
    [SerializeField] private Vector3Data targetPosition;
    [SerializeField] private FloatData speed;


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.GetValue(), speed.value * Time.deltaTime);
    }
}
