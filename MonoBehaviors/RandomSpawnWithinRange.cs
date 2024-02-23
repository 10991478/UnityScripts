using System.Collections;
using UnityEngine;

public class RandomSpawnWithinRange : MonoBehaviour
{
    [SerializeField] private Vector3 spawnRange, deadZone, spawnOffset;
    [SerializeField] private FloatData timeBetweenSpawns;
    [SerializeField] private BoolData continueSpawning;
    [SerializeField] private GameObject[] gameObjects;

    private WaitForSeconds waitForSecondsObj;

    private void Awake()
    {
        waitForSecondsObj = new WaitForSeconds(timeBetweenSpawns.value);
        spawnRange.x = Mathf.Abs(spawnRange.x);
        spawnRange.y = Mathf.Abs(spawnRange.y);
        spawnRange.z = Mathf.Abs(spawnRange.z);
        deadZone.x = Mathf.Abs(deadZone.x);
        deadZone.y = Mathf.Abs(deadZone.y);
        deadZone.z = Mathf.Abs(deadZone.z);
    }

    private void Start()
    {
        StartSpawning();
    }

    private IEnumerator Spawn()
    {
        while (continueSpawning.value)
        {
            yield return waitForSecondsObj;
            int topOrBottom = -1 + Random.Range(0, 2)*2;
            int leftOrRight = -1 + Random.Range(0, 2) * 2;
            float positionX = transform.position.x + leftOrRight * Random.Range(deadZone.x, spawnRange.x) + spawnOffset.x;
            float positionZ = transform.position.z + topOrBottom * Random.Range(deadZone.z, spawnRange.z) + spawnOffset.z;
            Vector3 spawnPoint = new Vector3(positionX, transform.position.y + spawnOffset.y, positionZ);
            Instantiate(gameObjects[Random.Range(0, gameObjects.Length)], spawnPoint, transform.rotation);
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(Spawn());
    }
}
