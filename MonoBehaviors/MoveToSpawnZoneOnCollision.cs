using UnityEngine;

public class MoveToSpawnZoneOnCollision : MonoBehaviour
{
    [SerializeField] SpawnZone[] spawnZones;
    [SerializeField] private bool relativeToSelf;
    [SerializeField] private Vector3 relativeOffset;

    private void OnTriggerEnter(Collider other)
    {
        int num = Random.Range(0, spawnZones.Length);
        SpawnZone spawnZone = spawnZones[num];
        float positionX = Random.Range(-1f * spawnZone.GetZone().x, spawnZone.GetZone().x) + spawnZone.GetOffset().x;
        float positionY = Random.Range(-1f * spawnZone.GetZone().y, spawnZone.GetZone().y) + spawnZone.GetOffset().y;
        float positionZ = Random.Range(-1f * spawnZone.GetZone().z, spawnZone.GetZone().z) + spawnZone.GetOffset().z;
        if (relativeToSelf) positionX += transform.position.x + relativeOffset.x;
        if (relativeToSelf) positionY += transform.position.y + relativeOffset.y;
        if (relativeToSelf) positionZ += transform.position.z + relativeOffset.z;
        Vector3 newPosition = new Vector3(positionX, positionY, positionZ);
        other.transform.position = newPosition;
    }
}
