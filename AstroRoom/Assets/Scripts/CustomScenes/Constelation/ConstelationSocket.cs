using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class ConstelationSocket : INode
{
    Color baseColor;
    public ConstelationController constelationController;

    [Space]
    public UnityEvent<int> onSocketHoverEnter;
    public UnityEvent<int> onSocketHoverExit;

    public UnityAction onSelect;
    public UnityAction onDeselect;
    // Start is called before the first frame update
    void Start()
    {//a hdyby dodawaæ na hover Action do triggera , a na exit usuwaæ ?????
        baseColor = GetComponent<Renderer>().material.color;
        constelationController.onReady += EnableCollider;
        constelationController.onComplete += DisableCollider;
        constelationController.onComplete += ClearSelected;
        constelationController.onComplete += SetBaseColor;


        onSelect += SetSelectedColor;
        onDeselect += SetBaseColor;
    }
    private void Update()
    {

        //zamiast tego zrobiæ Action w ConstelationCOntroller która jest wywo³ywana w momencie zaznaczenia
        if (constelationController.selected.Contains(id))
        {
            onSelect?.Invoke();

        }
        else
        {
            onDeselect?.Invoke();
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
    public void SetBaseColor()
    {
        GetComponent<Renderer>().material.color = baseColor;
    }

    public void SetSelectedColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void ClearSelected()
    {
        constelationController.selected.Clear();
    }
}
