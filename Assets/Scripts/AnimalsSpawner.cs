using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsSpawner : MonoBehaviour
{
    public int deerGroupsCount;
    public int wolfsCount;
    public int haresCount;
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
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetAnimalCounts(int deerGroupsCount, int wolfsCount, int haresCount)
    {
        this.deerGroupsCount = deerGroupsCount;
        this.wolfsCount = wolfsCount;
        this.haresCount = haresCount;
    }

    public void StartSimulation()
    {
        Bounds bounds = OrthographicBounds(Camera.main);
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
    private Bounds OrthographicBounds(Camera camera)
    {
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Bounds bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
