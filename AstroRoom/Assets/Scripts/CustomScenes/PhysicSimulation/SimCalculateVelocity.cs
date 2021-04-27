using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SimCalculateVelocity : MonoBehaviour
{

    public SimGravityObject relativeTo;
    public SimGravityObject gravityObject;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!gravityObject)
            gravityObject = GetComponent<SimGravityObject>();

        if (relativeTo == null)
            return;
        float dist = (transform.position - relativeTo.transform.position).magnitude;
        gravityObject.initialVelocity.x = Mathf.Sqrt((Constant.gravitionalConstant * relativeTo.GetComponent<Rigidbody>().mass) / dist);
    }
}
