using UnityEngine;

public class ConstantlyUpdatePosition : MonoBehaviour
{
    [SerializeField] private Vector3Data vectorObj;
    void Update()
    {
        vectorObj.SetValue(transform.position);
    }
}
