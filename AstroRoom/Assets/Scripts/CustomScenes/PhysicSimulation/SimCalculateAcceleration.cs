using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimCalculateAcceleration : MonoBehaviour
{
    public Vector3 Force(Rigidbody otherBody, Rigidbody rb)
    {
        float sqrDst = (otherBody.position - rb.position).magnitude;
        Vector3 forceDir = (otherBody.position - rb.position).normalized;

        float acceleration = Mathf.Sqrt(Constant.constG * otherBody.mass / sqrDst);
        Vector3 initialDir = new Vector3(forceDir.z, 0, -forceDir.x).normalized;
        return initialDir * acceleration;
    }
}
