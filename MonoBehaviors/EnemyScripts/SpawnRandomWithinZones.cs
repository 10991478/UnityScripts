using System.Collections;
using UnityEngine;

public class SpawnRandomWithinZones : MonoBehaviour
{
    [SerializeField] private SpawnZone[] spawnZones;
    [SerializeField] private FloatData timeBetweenSpawns;
    [SerializeField] private BoolData continueSpawning;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private bool relativeToSelf;
    [SerializeField] private Vector3 relativeOffset;

    private void Start()
    {
        StartSpawning();
    }

    private IEnumerator Spawn()
    {
        while (continueSpawning.value == true)
        {
            Debug.Log("Wait time: " + timeBetweenSpawns.value);
            yield return new WaitForSeconds(timeBetweenSpawns.value);
            int num = Random.Range(0, spawnZones.Length);
            Vector3 chosenZone = spawnZones[num].GetZone();
            Vector3 chosenOffset = spawnZones[num].GetOffset();
            float positionX = Random.Range(-1f * chosenZone.x, chosenZone.x) + chosenOffset.x;
            float positionY = Random.Range(-1f * chosenZone.y, chosenZone.y) + chosenOffset.y;
            float positionZ = Random.Range(-1f * chosenZone.z, chosenZone.z) + chosenOffset.z;
            if (relativeToSelf) positionX += transform.position.x + relativeOffset.x;
            if (relativeToSelf) positionY += transform.position.y + relativeOffset.y;
            if (relativeToSelf) positionZ += transform.position.z + relativeOffset.z;
            Vector3 spawnPoint = new Vector3(positionX, positionY, positionZ);
            Instantiate(gameObjects[Random.Range(0, gameObjects.Length)], spawnPoint, transform.rotation);
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(Spawn());
    }
}
