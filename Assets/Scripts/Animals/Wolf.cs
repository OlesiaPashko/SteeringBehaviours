using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Animal
{
    [SerializeField]
    private float lifetime;

    [SerializeField, Range(1, 20)]
    private float radius = 10f;

    private void Start()
    {
        lifetime = 60f;
    }

    private void Update()
    {
        ApplyForcesFromProviders();

        CheckAndUpdateLifetime();

        SmellPrey();
    }

    private void SmellPrey()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        int preysCount = 0;
        foreach (var collider in colliders)
        {
            GameObject otherAnimal = collider.gameObject;
            if (IsEatable(otherAnimal))
            {
                preysCount++;
                GetComponent<Seek>().objectToFollow = otherAnimal.transform;
            }
        }
        if(preysCount < 1)
        {
            GetComponent<Seek>().objectToFollow = null;
        }
    }

    private void CheckAndUpdateLifetime()
    {
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            lifetime -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var animal = collision.gameObject;
        if (IsEatable(animal))
        {
            Destroy(animal);
            lifetime += 60f;
        }
        OnCollision(collision);
    }

    private bool IsEatable(GameObject gameObject)
    {
        return gameObject.CompareTag("Hare") || gameObject.CompareTag("Player") || gameObject.CompareTag("Deer");
    }

}
