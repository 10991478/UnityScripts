using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehavior : MonoBehaviour
{
    public UnityEvent startEvent, startCountEvent, repeatCountEvent, endCountEvent, repeatUntilFalseEvent;
    public IntData counterNum;
    public bool canRun;
    private WaitForSeconds wfsObj;
    private WaitForFixedUpdate wffuObj;
    public float seconds = 3.0f;

    void Start()
    {
        wfsObj = new WaitForSeconds(seconds);
        wffuObj = new WaitForFixedUpdate();
        startEvent.Invoke();
    }
    public void StartCounting()
    {
        StartCoroutine(Counting());
    }
    private IEnumerator Counting()
    {

        startCountEvent.Invoke();
        yield return wfsObj;
        while (counterNum.value > 0)
        {
            yield return wfsObj;
            repeatCountEvent.Invoke();
            counterNum.AddValue(-1);
        }
        yield return wfsObj;
        endCountEvent.Invoke();
    }

    public void StartRepeatUntilFalse()
    {
        canRun = true;
        StartCoroutine(RepeatUntilFalse());
    }

    public void StopRepeatUntilFalse()
    {
        canRun = false;
    }

    private IEnumerator RepeatUntilFalse()
    {
        while (canRun)
        {
            yield return wfsObj;
            repeatUntilFalseEvent.Invoke();
        }
    }
}