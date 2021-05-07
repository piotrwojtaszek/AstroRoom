using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class ConstelationSocket : MonoBehaviour
{
    [HideInInspector]
    public int id;
    Color baseColor;
    public InputActionReference teleportationActivationReference;

    [Space]
    public UnityEvent onTeleportationActive;
    public UnityEvent onTeleportationCancel;
    // Start is called before the first frame update
    void Start()
    {//a hdyby dodawaæ na hover Action do triggera , a na exit usuwaæ ?????
        baseColor = GetComponent<Renderer>().material.color;


        teleportationActivationReference.action.performed += TeleportationActive;
        teleportationActivationReference.action.canceled += TeleportationCancel;
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


}
