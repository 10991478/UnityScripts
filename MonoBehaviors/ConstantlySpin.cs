using UnityEngine;

public class ConstantlySpin : MonoBehaviour
{
    public float x,y,z;
    void FixedUpdate()
    {
        transform.Rotate(x, y, z);
    }
}
