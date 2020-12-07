using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoidance : DesiredVelocityProvider
{
    [SerializeField, Range(1, 20)]
    private float radius = 10f;
    public override Vector3 GetDesiredVelocity()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        Vector2 sum = Vector2.zero;
        int count = 0;
        foreach(var collider in colliders)
        {
            GameObject otherAnimal = collider.gameObject;
            if (otherAnimal.CompareTag("Deer"))
            {
                Vector2 desiredVelocity = transform.position - otherAnimal.transform.position;
                float distance = (desiredVelocity).magnitude;
                if (distance > 0)
                {
                    sum += desiredVelocity.normalized;
                   // Debug.Log("sum = " + sum);
                    count++;
                }
            }
        }
        if (count > 0)
        {
            return sum / count;
        }
        return Vector2.zero;
    }
}
