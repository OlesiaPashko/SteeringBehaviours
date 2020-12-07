using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cohesion : DesiredVelocityProvider
{
    [SerializeField, Range(1, 20)]
    private float radius = 10f;
    public override Vector3 GetDesiredVelocity()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        Vector3 sum = Vector2.zero;
        int count = 0;
        foreach (var collider in colliders)
        {
            GameObject otherAnimal = collider.gameObject;
            if (otherAnimal.CompareTag("Deer"))
            {
                Vector2 desiredVelocity = transform.position - otherAnimal.transform.position;
                float distance = (desiredVelocity).magnitude;
                if (distance > 0)
                {
                    sum += otherAnimal.transform.position;
                    //Debug.Log("sum = " + sum);
                    count++;
                }
            }
        }
        if (count > 0)
        {
            sum /= count;
            return Seek(sum, 10f);

        }
        return Vector2.zero;
    }

    private Vector3 Seek(Vector3 objectToSeek, float radiusToStop)
    {
        var velocity = objectToSeek - transform.position;
        if (velocity.magnitude < radiusToStop)
        {
            return velocity.normalized * Animal.VelocityLimit * (velocity.magnitude / radiusToStop);
        }
        return velocity.normalized * Animal.VelocityLimit;
    }
}
