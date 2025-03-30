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

    void Start()
    {
        
    }

    public void StartSpawning()
    {
        if (!appear)
        {
            appear = true;
            SpawnStars();
        }
    }

    void SpawnStars()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            float randomX = Random.Range(MinX, MaxX);
            float randomY = Random.Range(MinY, MaxY);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            Instantiate(starPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

//    private bool Action = false;

//    public void StartFall()
//    {
//        if (!Action)
//        {
//            Action = true;
//            StartCoroutine(SpawnStars());
//        }
       
//    }

//    IEnumerator SpawnStars()
//    {
//        while (Action)
//        {
//            float randomX = Random.Range(Min, Max);
//            Vector3 spawnPosition = new Vector3(randomX, High, 0);
//            Instantiate(starPrefab, spawnPosition, Quaternion.identity);

//            yield return new WaitForSeconds(chu_ki);
//        }
//    }
//}
