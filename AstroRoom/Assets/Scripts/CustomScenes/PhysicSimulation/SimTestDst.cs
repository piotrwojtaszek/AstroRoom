using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SimTestDst : MonoBehaviour
{
    public SimGravityObject gravityObject;
    public SimCalculateAcceleration simCalculate;
    public float orbitalTime;

    private void Start()
    {
        if (gravityObject == null)
            gravityObject = GetComponent<SimGravityObject>();
        if (simCalculate == null)
            simCalculate = GetComponent<SimCalculateAcceleration>();
    }
    void Update()
    {
        if (gravityObject == null)
            gravityObject = GetComponent<SimGravityObject>();
        if (simCalculate == null)
            simCalculate = GetComponent<SimCalculateAcceleration>();

        float sqrDst = (gravityObject.relativeTo.transform.position - GetComponent<Rigidbody>().position).magnitude;
        Vector3 forceDir = (gravityObject.relativeTo.transform.position - GetComponent<Rigidbody>().position).normalized;

        float acceleration = Mathf.Sqrt(Constant.constG * gravityObject.relativeTo.GetComponent<Rigidbody>().mass / sqrDst);
        Vector3 initialDir = new Vector3(forceDir.z, 0, -forceDir.x).normalized;

        float okres = (2f * Mathf.PI * sqrDst / (initialDir * acceleration).magnitude);
        orbitalTime = okres * (1f / 72f) / SimController.Instance.timeStep;

    }
}
