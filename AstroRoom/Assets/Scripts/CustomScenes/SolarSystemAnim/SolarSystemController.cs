using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public float sizeMultiplier=1f;
    public float speedMultiplier = 1f;

}
