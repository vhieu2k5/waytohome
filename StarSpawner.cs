using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab;
    public int numberOfStars = 15;
    public float MinX = -7f, MaxX = 7f;
    public float MinY = 1.5f, MaxY = 4f;
    private bool appear = false;

    public int StartSpawning()
    {
        if (!appear)
        {
            appear = true;
            return SpawnStars(); // Trả về số sao đã spawn
        }
        return 0; // Nếu đã spawn rồi thì không spawn thêm nữa
    }

    private int SpawnStars()
    {
        int starsSpawned = 0;

        for (int i = 0; i < numberOfStars; i++)
        {
            float randomX = Random.Range(MinX, MaxX);
            float randomY = Random.Range(MinY, MaxY);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            Instantiate(starPrefab, spawnPosition, Quaternion.identity);
            starsSpawned++;
        }

        return starsSpawned; // Trả về số lượng sao thực tế đã spawn
    }
}
