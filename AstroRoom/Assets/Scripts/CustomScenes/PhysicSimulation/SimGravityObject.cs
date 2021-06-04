using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGravityObject : MonoBehaviour
{
    public BodyType bodyType = BodyType.Planet;
    public Rigidbody rb { get; set; }
    public SimGravityObject relativeTo;
    public Vector3 initialVelocity;
    [HideInInspector]
    public Vector3 velocity;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        velocity = initialVelocity;
    }

    private void UpdateVelocityPlanet(SimGravityObject[] allBodies)
    {
        foreach (var otherBody in allBodies)
        {
            if (otherBody.bodyType == BodyType.Static)
            {
                if (otherBody != this)
                {
                    float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude;
                    Vector3 forceDir = (otherBody.rb.position - rb.position).normalized;

                    Vector3 acceleration = Constant.gravitionalConstant * forceDir * otherBody.rb.mass / sqrDst;
                    velocity += acceleration * SimController.Instance.timeStep;
                }
            }
        }
    }

    public void UpdatePosition()
    {
        rb.MovePosition(rb.position + velocity * SimController.Instance.timeStep);
    }

    public void Move(SimGravityObject[] allBodies)
    {
        if (bodyType == BodyType.Static)
            return;
        UpdateVelocityPlanet(allBodies);
    }
}

public enum BodyType
{
    Static,
    Planet,
}
