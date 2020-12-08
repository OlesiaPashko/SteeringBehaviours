using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsSpawner : MonoBehaviour
{
    public static int deerGroupsCount;
    public static int wolfsCount;
    public static int haresCount;
    public GameObject wolf;
    public GameObject deer;
    public GameObject hare;

    private static AnimalsSpawner _instance;

    public static AnimalsSpawner Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        Bounds bounds = Camera.main.OrthographicBounds();
        SpawnDeers(bounds);
        SpawnHares(bounds);
        SpawnWolfs(bounds);
    }

    private void SpawnWolfs(Bounds bounds)
    {
        for (int i = 0; i < wolfsCount; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            Instantiate(wolf, new Vector2(randomX, randomY), Quaternion.identity);
        }
    }

    private void SpawnHares(Bounds bounds)
    {
        for (int i = 0; i < haresCount; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            Instantiate(hare, new Vector2(randomX, randomY), Quaternion.identity);
        }
    }

    private void SpawnDeers(Bounds bounds)
    {
        for (int i = 0; i < deerGroupsCount; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            Instantiate(deer, new Vector2(randomX, randomY), Quaternion.identity);
        }
    }
}
