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
        float sqrDst = (relativeTo.GetComponent<Rigidbody>().position - gravityObject.GetComponent<Rigidbody>().position).magnitude;
        Vector3 forceDir = (relativeTo.GetComponent<Rigidbody>().position - gravityObject.GetComponent<Rigidbody>().position).normalized;

        float acceleration = Mathf.Sqrt(Constant.gravitionalConstant * relativeTo.GetComponent<Rigidbody>().mass / sqrDst);
        Vector3 initialDir = new Vector3(forceDir.z, 0, -forceDir.x).normalized;
        gravityObject.GetComponent<SimGravityObject>().initialVelocity = initialDir * acceleration;
    }
}
