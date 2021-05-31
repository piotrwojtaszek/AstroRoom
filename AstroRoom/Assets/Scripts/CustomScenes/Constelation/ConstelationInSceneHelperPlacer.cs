using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ConstelationInSceneHelperPlacer : MonoBehaviour
{
    public ConstelationInSceneHelper sceneHelper;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(-sceneHelper.constelationPreset.skyPosition.x, sceneHelper.constelationPreset.skyPosition.y, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.GetChild(0).position,2f);
    }
}
