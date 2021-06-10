using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimCalculateAcceleration : MonoBehaviour
{
    private SimGravityObject relativeTo;
    public SimGravityObject gravityObject;
    Rigidbody otherBody;
    Rigidbody rb;
    void OnEnable()
    {
        relativeTo = GetComponent<SimGravityObject>().relativeTo;
        otherBody = relativeTo.GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        Force();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
    }

    public void Force()
    {
        float sqrDst = (otherBody.position - rb.position).magnitude;
        Vector3 forceDir = (otherBody.position - rb.position).normalized;

        float acceleration = Mathf.Sqrt(Constant.constG * otherBody.mass / sqrDst);
        Vector3 initialDir = new Vector3(forceDir.z, 0, -forceDir.x).normalized;
        GetComponent<SimGravityObject>().initialVelocity = initialDir * acceleration;
    }
}
