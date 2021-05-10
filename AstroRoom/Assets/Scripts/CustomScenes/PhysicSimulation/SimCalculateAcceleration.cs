using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SimCalculateAcceleration : MonoBehaviour
{
    private SimGravityObject relativeTo;
    public SimGravityObject gravityObject;
 
    void Awake()
    {
        relativeTo = GetComponent<SimGravityObject>().relativeTo;
        gravityObject = GetComponent<SimGravityObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        float dist = (transform.position - relativeTo.transform.position).magnitude;
        gravityObject.initialVelocity.x = Mathf.Sqrt((Constant.gravitionalConstant * relativeTo.GetComponent<Rigidbody>().mass) / dist);
        Vector3 dotProduct = Vector3.Cross(transform.position, relativeTo.transform.position);
        Vector3 nowy = new Vector3(dotProduct.z, -dotProduct.y, dotProduct.x);
        Gizmos.DrawRay(transform.position, nowy.normalized);
        Force();
    }

    void Force()
    {
        float sqrDst = (relativeTo.GetComponent<Rigidbody>().position - gravityObject.GetComponent<Rigidbody>().position).magnitude;
        Vector3 forceDir = (relativeTo.GetComponent<Rigidbody>().position - gravityObject.GetComponent<Rigidbody>().position).normalized;

        float acceleration = Mathf.Sqrt(Constant.gravitionalConstant * relativeTo.GetComponent<Rigidbody>().mass / sqrDst);
        Vector3 nowy = new Vector3(forceDir.z, 0, -forceDir.x);
        var dotProduct = Vector3.Dot(nowy, forceDir * acceleration);
        nowy = new Vector3(forceDir.z, 0, -forceDir.x).normalized;
        gravityObject.GetComponent<SimGravityObject>().initialVelocity = nowy * acceleration;
    }
}
