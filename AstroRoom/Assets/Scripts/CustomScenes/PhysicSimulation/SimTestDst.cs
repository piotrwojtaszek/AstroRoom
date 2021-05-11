using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SimTestDst : MonoBehaviour
{
    private SimGravityObject relativeTo;
    public SimGravityObject gravityObject;
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


        float dst = (Vector3.zero - gravityObject.transform.position).magnitude;
        float okres = (2f * Mathf.PI * dst / gravityObject.initialVelocity.magnitude);
        orbitalTime = okres * Time.deltaTime/SimController.Instance.timeStep;

    }
}
