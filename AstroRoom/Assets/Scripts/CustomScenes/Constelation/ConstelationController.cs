using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationController : MonoBehaviour
{
    public SOConstelationBase constelationPreset = null;


    public void CreateHelpers()
    {
        foreach(Node node in constelationPreset.nodes)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = node.position;
        }
    }
}
