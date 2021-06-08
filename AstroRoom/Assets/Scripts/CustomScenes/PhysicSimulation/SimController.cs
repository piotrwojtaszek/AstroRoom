using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimController : MonoBehaviour
{
    SimGravityObject[] bodies;
    private static SimController _instance;
    public static SimController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SimController>();
            }

            return _instance;
        }
    }
    [Range(0f, 0.1f)]
    public float timeStep = .01f;

    private void Start()
    {
        bodies = FindObjectsOfType<SimGravityObject>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdateVelocity(bodies);
        }
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition();
        }
    }
}

[SerializeField]
public static class Constant
{
    public static float constG = .0667f;
}
