using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ConstelationEdgeDebug : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Edge edge;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
/*        lineRenderer.SetPosition(0, edge.point_1.position);
        lineRenderer.SetPosition(1, edge.point_2.position);
        transform.position = Vector3.Lerp(edge.point_1.position, edge.point_2.position, 0.5f);*/
    }

}
