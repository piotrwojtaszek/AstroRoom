using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimGravityObject : MonoBehaviour
{
    public BodyType bodyType = BodyType.Planet;
    //jesli moon to orbituje dookola najblizszej planety
    //jesli planeta to orbituje dookola slonca
    //jesli static to static
    //jesli free to oddzialuje wszystko 

    public Rigidbody rb { get; set; }
    public SimGravityObject relativeTo;

    public Vector3 initialVelocity;

    [HideInInspector]
    public Vector3 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        velocity = initialVelocity;
        if (bodyType == BodyType.Moon)
            transform.parent = relativeTo.transform;
    }

    private void UpdateVelocity(SimGravityObject[] allBodies)
    {
        foreach (var otherBody in allBodies)
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

    private void UpdateVelocityMoon(SimGravityObject relative)
    {

        transform.RotateAround(transform.parent.position, transform.up, 5f * Time.deltaTime);


    }

    public void UpdatePosition(float timeStep)
    {
        rb.MovePosition(rb.position + velocity * timeStep);
    }

    public void Move(SimGravityObject[] allBodies)
    {
        if (bodyType == BodyType.Static)
            return;

        else if (bodyType == BodyType.Free)
            UpdateVelocity(allBodies);

        else if (bodyType == BodyType.Planet)
            UpdateVelocityPlanet(allBodies);

        else if (bodyType == BodyType.Moon)
            UpdateVelocityMoon(relativeTo);
/*        UpdatePosition(SimController.Instance.timeStep);*/
    }
}

public enum BodyType
{
    Static,
    Planet,
    Moon,
    Free
}
