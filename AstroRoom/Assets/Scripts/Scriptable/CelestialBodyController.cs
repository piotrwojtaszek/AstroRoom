using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New celestial body",menuName ="Celestal Body/Controller")]
public class CelestialBodyController : ScriptableObject
{
    public CelestialBodyProperties properties;
}

[System.Serializable]
public class CelestialBodyProperties
{
    [SerializeField]
    private string bodyName;
    [SerializeField]
    private GameObject graphicPrefab;


    public string Name
    {
        get
        {
            return bodyName;
        }
    }

    public GameObject GraphicPrefab
    {
        get
        {
            return graphicPrefab;
        }
    }
}
