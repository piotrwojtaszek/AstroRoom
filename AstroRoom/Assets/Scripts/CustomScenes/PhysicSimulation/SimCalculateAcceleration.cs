using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SimCalculateAcceleration : MonoBehaviour
{
    private SimGravityObject relativeTo;
    public SimGravityObject gravityObject;
 
    void OnEnable()
    {
        relativeTo = GetComponent<SimGravityObject>().relativeTo;
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
        float sqrDst = (relativeTo.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).magnitude;
        Vector3 forceDir = (relativeTo.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).normalized;

        float acceleration = Mathf.Sqrt(Constant.gravitionalConstant * relativeTo.GetComponent<Rigidbody>().mass / sqrDst);
        Vector3 initialDir = new Vector3(forceDir.z, 0, -forceDir.x).normalized;
        GetComponent<SimGravityObject>().initialVelocity = initialDir * acceleration;
    }
}
