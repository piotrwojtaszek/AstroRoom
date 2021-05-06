using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstelationSocket : MonoBehaviour
{
    [HideInInspector]
    public int id;
    Color baseColor;

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
        if (ConstelationController.instance.selected.Contains(id))
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
        if (!ConstelationController.instance.selected.Contains(id))
        {
            if (ConstelationController.instance.selected.Count == 2)
                ConstelationController.instance.selected.RemoveAt(0);
            else
                ConstelationController.instance.selected.Add(id);

        }
        else
        {
            ConstelationController.instance.selected.Remove(id);
        }
        ConstelationController.instance.CheckConnection();
    }
    public void SocketDeselect()
    {
        GetComponent<Renderer>().material.color = baseColor;
    }


}
