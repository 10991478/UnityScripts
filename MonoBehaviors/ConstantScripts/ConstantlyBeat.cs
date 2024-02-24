using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantlyBeat : MonoBehaviour
{
    public float x,y,z;
    void Update()
    {
        transform.Rotate(x,y,z);
    }
}
