using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformList;

    public float minX;
    public float maxX;
    public float spawnTime;
    public float spawnTime1;
    public float spawnTime2;
    public float spawnTime3;
    public float spawnTime4;
    public float spawnTime5;
    public float platformSpeed1;
    public float platformSpeed2;
    public float platformSpeed3;
    public float platformSpeed4;
    public float platformSpeed5;
    
    private float platformSpawned = 0;

    private float t = 0;
    private void Start()
    {
        StartCoroutine(SpawnPlatforms());
    }

    private void Update()
    {
        t += Time.deltaTime;
        if(t >= 0 && t < 30)
        {
            spawnTime = spawnTime1;
        }
        if(t >= 30 && t < 60)
        {
            spawnTime = spawnTime2;
        }
        if (t >= 60 && t < 120)
        {
            spawnTime = spawnTime3;
        }
        if (t >= 120 && t < 210)
        {
            spawnTime = spawnTime4;
        }
        if(t >= 210)
        {
            spawnTime = spawnTime5;
        }
    }
    IEnumerator SpawnPlatforms()
    {
        while(true)
        {
            int seed = Random.Range(0, 7);
            
            yield return new WaitForSeconds(spawnTime);

            platformSpawned += 1;
            if(platformSpawned % 4 == 0)
            {
                int rng = Random.Range(0, 7);
                int rng2 = Random.Range(0, 7);
                GameObject p1 = Instantiate(platformList[rng], new Vector3(Random.Range(-2.5f, -0.5f), transform.position.y, transform.position.z), Quaternion.identity);
                GameObject p2 = Instantiate(platformList[rng2], new Vector3(Random.Range(5f, 8), transform.position.y, transform.position.z), Quaternion.identity);
                if (t >= 0 && t < 30)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed1;
                    p2.GetComponent<PlatformProps>().speed = platformSpeed1;
                }
                if (t >= 30 && t < 60)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed2;
                    p2.GetComponent<PlatformProps>().speed = platformSpeed2;
                }
                if (t >= 60 && t < 120)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed3;
                    p2.GetComponent<PlatformProps>().speed = platformSpeed3;
                }
                if (t >= 120 && t < 210)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed4;
                    p2.GetComponent<PlatformProps>().speed = platformSpeed4;
                }
                if (t >= 210)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed5;
                    p2.GetComponent<PlatformProps>().speed = platformSpeed5;
                }
                Destroy(p1, 20f);
                Destroy(p2, 20f);
            }
            else
            {
                int rng = Random.Range(0, 7);
                GameObject p1 = Instantiate(platformList[rng], new Vector3(Random.Range(minX, maxX), transform.position.y, transform.position.z), Quaternion.identity);
                if (t >= 0 && t < 30)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed1;
                }
                if (t >= 30 && t < 60)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed2;
                }
                if (t >= 60 && t < 120)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed3;
                }
                if (t >= 120 && t < 210)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed4;
                }
                if (t >= 210)
                {
                    p1.GetComponent<PlatformProps>().speed = platformSpeed5;
                }
                Destroy(p1, 20f);
            }
        }
    }
}
