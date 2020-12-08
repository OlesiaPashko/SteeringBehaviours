using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : Animal
{
    [SerializeField, Range(1, 20)]
    private float radius = 10f;

    void Update()
    {
        ApplyForcesFromProviders();
    }

    private void Start()
    {
        Avoidance av = GetComponent<Avoidance>();
        av.tagsToAvoid = new string[] { "Player", "Wolf" };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);
    }
}
