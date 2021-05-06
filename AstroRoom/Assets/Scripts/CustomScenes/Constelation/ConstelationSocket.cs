using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationSocket : MonoBehaviour
{
    [HideInInspector]
    public int id;
    Color baseColor;
    public static List<int> selected = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        /*        ConstelationEvents.current.onSocketTriggerEnter += SocketTriggerEnter;
                ConstelationEvents.current.onSocketTriggerExit += SocketTriggerExit;*/
        baseColor = GetComponent<Renderer>().material.color;
    }

    public void SocketTriggerExit(int id)
    {
        /*GetComponent<Renderer>().material.color = Color.red;*/
    }
    private void Update()
    {
        if (selected.Contains(id))
        {
            GetComponent<Renderer>().material.color = Color.red;

        }
        else
        {
            GetComponent<Renderer>().material.color = baseColor;
        }
    }

    public void SocketSelect()
    {
        if (!selected.Contains(id))
        {
            if (selected.Count == 1)
                AddEdge();
            else
                /*                selected.RemoveAt(0);*/
                selected.Add(id);

        }
        else
        {
            selected.Remove(id);
        }
    }
    public void AddEdge()
    {
        selected.Add(id);
        GameObject line = Instantiate(Resources.Load("Custom/Scriptable/Constelations/ConstelationEdgePrefab") as GameObject, transform);
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, ConstelationController.instance.constelationPreset.nodes[selected[0]].position + new Vector3(0, 0, transform.position.z));
        lineRenderer.SetPosition(1, ConstelationController.instance.constelationPreset.nodes[selected[1]].position + new Vector3(0, 0, transform.position.z));
        selected.Clear();
    }
    public void SocketDeselect()
    {
        GetComponent<Renderer>().material.color = baseColor;
    }


}
