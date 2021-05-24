using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New celestial body",menuName ="Extended/Celestial Body")]
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
    [SerializeField]
    private float size;

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

    public float Size
    {
        get
        {
            return size;
        }
    }
}
