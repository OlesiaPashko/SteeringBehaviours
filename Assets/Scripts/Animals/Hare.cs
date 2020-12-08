using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hare : Animal
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
        av.tagsToAvoid = new string[] { "Hare", "Player", "Deer", "Wolf" };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);
    }
}
