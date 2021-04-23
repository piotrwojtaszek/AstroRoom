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

    private void Awake()
    {
        bodies = FindObjectsOfType<SimGravityObject>();
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < bodies.Length; i++)
        {
            bodies[i].Move(bodies);
        }
    }

    public float timeStep = .01f;
    public float gravitionalConstant = 66.7f;
}
