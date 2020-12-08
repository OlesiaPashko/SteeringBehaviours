using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DesiredVelocityProvider:MonoBehaviour
{
    [SerializeField, Range(0, 10)]
    private float weight = 1;

    public float Weight { get { return weight; } set { weight = value; } }

    protected Animal Animal;

    private void Awake()
    {
        Animal = GetComponent<Animal>();
    }
    public abstract Vector3 GetDesiredVelocity();
}
