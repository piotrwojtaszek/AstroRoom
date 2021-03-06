using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SolarSystemController : MonoBehaviour
{
    private static SolarSystemController _instance;
    public static SolarSystemController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SolarSystemController>();
            }

            return _instance;
        }
    }
    SolarSystemOrbitController[] bodies;
    [Range(.01f, 2f)]
    public float sizeMultiplier = 1f;
    [Range(.001f, .25f)]
    public float speedMultiplier = 1f;
    public UnityAction onSizeChange;
    private void Awake()
    {
        bodies = FindObjectsOfType<SolarSystemOrbitController>();
    }
    private void Start()
    {
        onSizeChange += ChangeSize;
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition();
        }
    }

    void ChangeSize()
    {
        transform.localScale = Vector3.one * sizeMultiplier;
    }
}
