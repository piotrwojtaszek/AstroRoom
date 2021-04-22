using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIComparisonController : MonoBehaviour
{
    public UICelestialList celestialList;
    public Transform celestialBodyOrigin;


    public void OnClicked(CelestialBodyController bodyPrefab)
    {
        foreach(Transform child in celestialBodyOrigin)
        {
            Destroy(child.gameObject);
        }

        Instantiate(bodyPrefab.properties.GraphicPrefab, celestialBodyOrigin);

    }
}
