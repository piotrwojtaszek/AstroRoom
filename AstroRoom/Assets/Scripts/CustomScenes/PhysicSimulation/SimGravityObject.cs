using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGravityObject : MonoBehaviour
{
    public BodyType bodyType = BodyType.Planet;
    public Rigidbody rb;
    public SimGravityObject relativeTo;
    public Vector3 initialVelocity;
    public Vector3 velocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        velocity = initialVelocity;
    }

    public void UpdateVelocity(SimGravityObject[] allBodies)
    {
        if (bodyType == BodyType.Static)
            return;

        foreach (var otherBody in allBodies)
        {
            if (otherBody.bodyType == BodyType.Static)
            {
                if (otherBody != this)
                {
                    float sqrDistance = (otherBody.rb.position - rb.position).sqrMagnitude;
                    Vector3 forceDirection = (otherBody.rb.position - rb.position).normalized;

                    Vector3 acceleration = Constant.constG * otherBody.rb.mass / sqrDistance * forceDirection;
                    velocity += acceleration * SimController.Instance.timeStep;
                }
            }
        }
    }

    public void UpdatePosition()
    {
        rb.MovePosition(rb.position + velocity * SimController.Instance.timeStep);
    }
}

public enum BodyType
{
    Static,
    Planet,
}
