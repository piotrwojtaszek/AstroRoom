using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationEdge : MonoBehaviour
{
    public int id_1;
    public int id_2;
    LineRenderer lineRenderer;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, ConstelationController.instance.nodes[id_1].position);
        lineRenderer.SetPosition(1, ConstelationController.instance.nodes[id_2].position);
    }
}
