using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Animal : MonoBehaviour
{
    protected Vector3 velocity;
    protected Vector3 acceleration;

    public Vector3 Velocity { 
        get
        {
            return velocity;
        }
        set
        {
            velocity = value;
        }
    }

    [SerializeField]
    private float mass = 1;

    [SerializeField, Range(1, 20)]
    private static float velocityLimit = 3;

    [SerializeField, Range(1, 20)]
    private float steeringForceLimit = 3;

    private const float Epsilon = 0.01f;
    public float VelocityLimit => velocityLimit;

    public void ApplyForce(Vector3 force)
    {
        force /= mass;
        acceleration += force;
    }

    protected void OnCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
    }

    protected void ApplyForcesFromProviders()
    {
        ApplyFriction();

        ApplySteeringForce();

        ApplyForces();

        void ApplyFriction()
        {
            var friction = -velocity.normalized * 0.5f;
            ApplyForce(friction);
        }

        void ApplySteeringForce()
        {
            var providers = GetComponents<DesiredVelocityProvider>();
            if (providers.Length == 0)
            {
                // Debug.LogError("Here");
                return;
            }
            Vector3 desiredVelocity = Vector3.zero;
            foreach (var provider in providers)
            {
                var velocity = provider.GetDesiredVelocity();
                desiredVelocity += velocity.normalized * provider.Weight;
            }
            var steeringForce = desiredVelocity - velocity;

            ApplyForce(steeringForce.normalized * steeringForceLimit);
        }
    void Update()
    {
        ApplyForcesFromProviders();
    }

        void ApplyForces()
        {
            velocity += acceleration * Time.deltaTime;

            velocity = Vector3.ClampMagnitude(velocity, velocityLimit);

            if(velocity.magnitude < Epsilon)
            {
                velocity = Vector3.zero;
                return;
            }

            transform.position += velocity * Time.deltaTime;
            acceleration = Vector3.zero;
        }
    }
}
