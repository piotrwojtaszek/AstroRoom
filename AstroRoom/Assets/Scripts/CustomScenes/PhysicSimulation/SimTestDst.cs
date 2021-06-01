using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SimTestDst : MonoBehaviour
{
    private SimGravityObject relativeTo;
    public SimGravityObject gravityObject;
    public SimCalculateAcceleration simCalculate;
    public float orbitalTime;
    void Start()
    {
        /*        relativeTo = GetComponent<SimGravityObject>().relativeTo;
                gravityObject = GetComponent<SimGravityObject>();*/
    }

    // Update is called once per frame
    void Update()
    {
        if (gravityObject == null)
            gravityObject = GetComponent<SimGravityObject>();
        if (simCalculate == null)
            simCalculate = GetComponent<SimCalculateAcceleration>();
        if (simCalculate != null)
            simCalculate.Force();
        float dst = (Vector3.zero - gravityObject.transform.position).magnitude;
        float okres = (2f * Mathf.PI * dst / gravityObject.initialVelocity.magnitude);
        orbitalTime = okres * Time.fixedDeltaTime / SimController.Instance.timeStep;

    }
}
