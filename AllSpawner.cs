using System.Collections;
using UnityEngine;

public class AllSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnConfig
    {
        public GameObject[] prefabs;
        public float minInterval = 1f;
        public float maxInterval = 3f;
        public float spawnX = 10f;
        public float minY = -2f;
        public float maxY = -2f;  
    }

    public SpawnConfig obstacleConfig;
    public SpawnConfig giftConfig;

    private void Start()
    {
        StartCoroutine(SpawnRoutine(obstacleConfig));
        StartCoroutine(SpawnRoutine(giftConfig));
    }

    IEnumerator SpawnRoutine(SpawnConfig config)
    {
        while (true)
        {
            float waitTime = Random.Range(config.minInterval, config.maxInterval);
            yield return new WaitForSeconds(waitTime);

            Spawn(config);
        }
    }

    void Spawn(SpawnConfig config)
    {
        if (config.prefabs.Length == 0) return;

        int index = Random.Range(0, config.prefabs.Length);
        float spawnY = Random.Range(config.minY, config.maxY);
        Vector2 spawnPos = new Vector2(config.spawnX, spawnY);

        Instantiate(config.prefabs[index], spawnPos, Quaternion.identity);
    }
}
