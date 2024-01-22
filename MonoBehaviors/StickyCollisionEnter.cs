using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCollisionEnter : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.transform.parent == null) other.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision other) {
        if (other.transform.parent == transform) other.transform.SetParent(null);
    }
}