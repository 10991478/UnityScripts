using UnityEngine;

public class ConstantlyMoveForward : MonoBehaviour
{
    [SerializeField] private float speed;


    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
