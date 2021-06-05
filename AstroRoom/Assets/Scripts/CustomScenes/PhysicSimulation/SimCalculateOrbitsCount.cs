using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimCalculateOrbitsCount : IOrbitsCount
{
    public LayerMask layerMask;
    private bool alreadyHit = true;
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.left, Mathf.Infinity, layerMask))
        {
            if (alreadyHit == false)
                orbitsCount++;
            alreadyHit = true;
        }
        else
        {
            alreadyHit = false;
        }
    }
}
