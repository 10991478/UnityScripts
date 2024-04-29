using UnityEngine;
using UnityEngine.Events;

public class InstantiateGameObjectBehavior : MonoBehaviour
{
    [SerializeField] private GameObject instanceObject;
    [SerializeField] private Vector3Data position, rotation;

    public void InstantiateObject()
    {
        GameObject.Instantiate(instanceObject, position.GetValue(),
            new Quaternion(rotation.GetValue().x, rotation.GetValue().y, rotation.GetValue().z, 1));
    }
}
