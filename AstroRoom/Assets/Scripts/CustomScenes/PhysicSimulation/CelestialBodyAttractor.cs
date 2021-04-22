using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBodyAttractor : MonoBehaviour
{

    public float mass;
    public float radius;
    public Vector3 initialVelocity;
    Vector3 curentVelocity;


    private void Awake()
    {
        curentVelocity = initialVelocity;
    }

    public void UpdateVelocity(CelestialBodyAttractor[] allBodies, float timeStep)
    {

    }

}
