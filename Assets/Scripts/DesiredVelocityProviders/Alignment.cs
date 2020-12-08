using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : DesiredVelocityProvider
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
                Vector3 velocity = otherAnimal.GetComponent<Animal>().Velocity;
                sum += velocity.normalized;
                //Debug.Log("sum = " + sum);
                count++;
            }
        }
        if (count > 0)
        {
            return sum / count;
        }
        return Vector2.zero;
    }
}
