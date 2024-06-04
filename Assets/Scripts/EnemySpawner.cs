using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// How to spawn enemies referenced from: Modding by Kaupenjoe
// Reference: https://www.youtube.com/watch?v=SELTWo1XZ0c

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject elfPrefab;
    [SerializeField]
    private GameObject reindeerPrefab;
    [SerializeField]
    private GameObject flyerPrefab;

    [SerializeField]
    private float elfInterval = 1f;
    [SerializeField]
    private float reindeerInterval = 1f;
    [SerializeField]
    private float flyerInterval = 10f;

    // Randomized vector spawn point variables
    private float x;
    private float y;
    private float z;
    Vector3 spawnPosition;

    public int numMobsSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        numMobsSpawned = 0;
        StartCoroutine(spawnEnemy(elfInterval, elfPrefab));
        StartCoroutine(spawnEnemy(reindeerInterval, reindeerPrefab));
        StartCoroutine(spawnEnemy(flyerInterval, flyerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        x = transform.position.x + Random.Range(-10f, 10f);
        y = transform.position.y + Random.Range(0f, 5f);
        spawnPosition = new Vector3(x, y, 0);

        // Put a cap on how many enemies can spawn
        if (numMobsSpawned < 100) 
        {
            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
        // Otherwise start to slowdown spawn rates
        else 
        {
            interval += 10;
        }

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}