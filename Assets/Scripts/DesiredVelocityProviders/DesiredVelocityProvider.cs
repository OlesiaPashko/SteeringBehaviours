using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DesiredVelocityProvider:MonoBehaviour
{
    [SerializeField, Range(0, 3)]
    private float weight = 1;

    public float Weight => weight;

    protected Animal Animal;

    private void Awake()
    {
        Animal = GetComponent<Animal>();
    }
    public abstract Vector3 GetDesiredVelocity();
}
