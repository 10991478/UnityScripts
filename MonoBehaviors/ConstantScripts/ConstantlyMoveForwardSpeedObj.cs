using UnityEngine;

public class ConstantlyMoveForwardSpeedObj : MonoBehaviour
{
    [SerializeField] private FloatData speed;


    void Update()
    {
        transform.position += transform.forward * speed.value * Time.deltaTime;
    }
}
