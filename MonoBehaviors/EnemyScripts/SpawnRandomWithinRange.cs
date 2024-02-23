using System.Collections;
using UnityEngine;

public class SpawnRandomWithinRange : MonoBehaviour
{
    [SerializeField] private Vector3 spawnRange, spawnOffset;
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
            float positionX = transform.position.x + Random.Range(-1f * spawnRange.x, spawnRange.x) + spawnOffset.x;
            float positionZ = transform.position.z + Random.Range(-1f * spawnRange.z, spawnRange.z) + spawnOffset.z;
            Vector3 spawnPoint = new Vector3(positionX, transform.position.y + spawnOffset.y, positionZ);
            Instantiate(gameObjects[Random.Range(0, gameObjects.Length)], spawnPoint, transform.rotation);
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(Spawn());
    }
}
