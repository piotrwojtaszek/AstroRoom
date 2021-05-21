using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class ConstelationSocket : INode
{
    Color baseColor;
    public List<InputActionReference> socketActivationReference;
    public ConstelationController constelationController;

    [Space]
    public UnityEvent<int> onSocketHoverEnter;
    public UnityEvent<int> onSocketHoverExit;
    // Start is called before the first frame update
    void Start()
    {//a hdyby dodawa� na hover Action do triggera , a na exit usuwa� ?????
        baseColor = GetComponent<Renderer>().material.color;
        constelationController.onReady += EnableCollider;
        constelationController.onComplete += DisableCollider;
    }
    private void Update()
    {

        //zamiast tego zrobi� Action w ConstelationCOntroller kt�ra jest wywo�ywana w momencie zaznaczenia
        if (constelationController.selected.Contains(id))
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
        if (!constelationController.selected.Contains(id))
        {
            if (constelationController.selected.Count == 2)
                constelationController.selected.RemoveAt(0);
            else
                constelationController.selected.Add(id);

        }
        else
        {
            constelationController.selected.Remove(id);
        }
        constelationController.CheckConnection();
    }

    public void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    public void DisableCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
}
