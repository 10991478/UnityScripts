//For more documentation on this script, go to https://github.com/10991478/1610Spring2023/blob/main/Unit%206/UFO%20TopDown/Assets/Scripts/EnemySpawnManager.cs
//^^^ I wrote this script awhile ago that operates similarly to the one you're looking at
//range = L, curveSteepness = k, rangeOffset = h, timeOffset = m


using UnityEngine;

public class ChangeFloatValueLogisticallyOverTime : MonoBehaviour
{
    [SerializeField] private FloatData floatValue;
    [SerializeField] private float range, curveSteepness, timeOffset, rangeOffset;

    void Update()
    {
        floatValue.SetValue(LogisticFunction((float)Time.time));
    }


    float LogisticFunction(float x)
    {
        return (range / (1 + Mathf.Exp(-curveSteepness * (x - timeOffset))) + rangeOffset);
    }
}