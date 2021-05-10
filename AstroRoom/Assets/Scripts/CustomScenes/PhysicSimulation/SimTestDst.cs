using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimTestDst : MonoBehaviour
{
    private SimGravityObject relativeTo;
    public SimGravityObject gravityObject;

    void Start()
    {
        relativeTo = GetComponent<SimGravityObject>().relativeTo;
        gravityObject = GetComponent<SimGravityObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((relativeTo.transform.position - gravityObject.transform.position).magnitude);
    }
}
