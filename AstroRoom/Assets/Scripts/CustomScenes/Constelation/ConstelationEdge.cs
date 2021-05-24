using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationEdge : MonoBehaviour
{
    public int id_1;
    public int id_2;
    LineRenderer lineRenderer;
    public ConstelationController constelationController;
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        ConstelationEvents.Instance.onProgressReset += DestroyMe;
    }

    private void Update()
    {
        UpdatePos();
        lineRenderer.widthMultiplier = transform.lossyScale.x/20f;
    }


    public void UpdatePos()
    {
        lineRenderer.SetPosition(0, constelationController.nodes[id_1].position);
        lineRenderer.SetPosition(1, constelationController.nodes[id_2].position);
    }
    void DestroyMe()
    {
        ConstelationEvents.Instance.onProgressReset -= DestroyMe;
        Destroy(gameObject);
    }
}
