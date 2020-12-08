using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : DesiredVelocityProvider
{
    public Transform objectToFollow;
    public float radius = 10f;
    public override Vector3 GetDesiredVelocity()
    {
        if (objectToFollow == null)
            return Vector3.zero;

        var velocity = objectToFollow.position - transform.position;
        if (velocity.magnitude < radius)
        {
            return velocity.normalized * Animal.VelocityLimit * (velocity.magnitude/radius);
        }
        return velocity.normalized * Animal.VelocityLimit;
    }
}
