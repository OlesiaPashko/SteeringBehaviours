using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chest;

    [SerializeField]
    private float timeBetweenSpawns;

    void Start()
    {
        Bounds bounds = Camera.main.OrthographicBounds();
        StartCoroutine(SpawnChest(bounds));
    }

    private IEnumerator SpawnChest(Bounds bounds)
    {
        while (true)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomY = Random.Range(bounds.min.y, bounds.max.y);
            Instantiate(chest, new Vector2(randomX, randomY), Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
