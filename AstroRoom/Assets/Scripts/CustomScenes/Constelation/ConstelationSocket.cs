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


    [Space]
    public UnityEvent<int> onSocketHoverEnter;
    public UnityEvent<int> onSocketHoverExit;
    // Start is called before the first frame update
    void Start()
    {//a hdyby dodawaæ na hover Action do triggera , a na exit usuwaæ ?????
        baseColor = GetComponent<Renderer>().material.color;
    }
    private void Update()
    {

        //zamiast tego zrobiæ Action w ConstelationCOntroller która jest wywo³ywana w momencie zaznaczenia
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

    //na hover += a na exit -=
    public void OnHoverEnter()
    {
        foreach (InputActionReference inputAction in socketActivationReference)
        {
            inputAction.action.performed += SocketHoverEnter;
        }

        /*  socketActivationReference.action.canceled += SocketHoverExit;*/

    }

    public void OnHoverExit()
    {
        foreach (InputActionReference inputAction in socketActivationReference)
        {
            inputAction.action.performed -= SocketHoverEnter;
            /*socketActivationReference.action.canceled -= SocketHoverExit;*/
        }

    }


    private void SocketHoverExit(InputAction.CallbackContext obj)
    {
        onSocketHoverExit.Invoke(id);
    }


    private void SocketHoverEnter(InputAction.CallbackContext obj)
    {
        onSocketHoverEnter.Invoke(id);
    }

    public void EnterMessage()
    {
        Debug.Log("Hover enter");
    }
    public void ExitMessage()
    {
        Debug.Log("Hover exit");
    }
}
