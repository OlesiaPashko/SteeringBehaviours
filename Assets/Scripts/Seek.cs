using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : DesiredVelocityProvider
{
    //[SerializeField]
    // private Transform objectToFollow;
    public float radius = 10f;
    public override Vector3 GetDesiredVelocity()
    {
        //return (objectToFollow.position - transform.position).normalized * Animal.VelocityLimit;
        var velocity = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (velocity.magnitude < radius)
        {
            return velocity.normalized * Animal.VelocityLimit * (velocity.magnitude/radius);
        }
        return velocity.normalized * Animal.VelocityLimit;
    }
}
