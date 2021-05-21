using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimCalculateOrbitsCount : MonoBehaviour
{
    public int orbitsCount = -1;
    public LayerMask layerMask;
    private bool alreadyHit = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (alreadyHit == false)
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, Vector3.left, out hit, Mathf.Infinity, layerMask))
            {
                alreadyHit = true;
                orbitsCount++;
            }

        RaycastHit hit2;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, Vector3.right, out hit2, Mathf.Infinity, layerMask))
        {
            alreadyHit = false;
        }
    }
}
