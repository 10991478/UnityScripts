using UnityEngine;

[CreateAssetMenu]
public class SpawnZone : ScriptableObject
{
    [SerializeField] private Vector3 spawnZone, positionOffset;

    public Vector3 GetZone()
    {
        return spawnZone;
    }

    public Vector3 GetOffset()
    {
        return positionOffset;
    }
}
