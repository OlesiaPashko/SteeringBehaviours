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
        Avoidance[] avs = GetComponents<Avoidance>();
        avs[0].tagsToAvoid = new string[] { "Player", "Wolf" };
        avs[0].Weight = 5f;
        avs[1].tagsToAvoid = new string[] { "Deer" };
        avs[0].Weight = 2f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision(collision);
    }
}
