using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DraggableBehavior : MonoBehaviour
{
    private Camera cameraObj;
    public bool draggable;
    public bool everythingFrozen;
    public Vector3 position, offset;
    public UnityEvent startDragEvent, endDragEvent;
    private WaitForFixedUpdate wffuObj;

    void Awake()
    {
        cameraObj = Camera.main;
        everythingFrozen = true;
    }

    public IEnumerator OnMouseDown()
    {
        if (!everythingFrozen)
        {
            offset = transform.position - cameraObj.ScreenToWorldPoint(Input.mousePosition);
            draggable = true;
            startDragEvent.Invoke();
            yield return wffuObj;

            while (draggable & !everythingFrozen)
            {
                yield return wffuObj;
                position = cameraObj.ScreenToWorldPoint(Input.mousePosition) + offset;
                transform.position = position;
            }
        }
    }

    void OnMouseUp()
    {
        if (!everythingFrozen)
        {
            draggable = false;
            endDragEvent.Invoke();
        }
    }

    public void SetDraggable(bool canDrag)
    {
        everythingFrozen = !canDrag;
    }
}