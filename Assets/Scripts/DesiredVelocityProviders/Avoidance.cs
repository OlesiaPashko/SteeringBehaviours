using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Avoidance : DesiredVelocityProvider
{
    [SerializeField, Range(1, 20)]
    private float radius = 10f;

    public string[] tagsToAvoid;
    public override Vector3 GetDesiredVelocity()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        Vector2 sum = Vector2.zero;
        int count = 0;
        foreach(var collider in colliders)
        {
            GameObject otherAnimal = collider.gameObject;
            if (tagsToAvoid.Any(x=>otherAnimal.CompareTag(x)))
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
