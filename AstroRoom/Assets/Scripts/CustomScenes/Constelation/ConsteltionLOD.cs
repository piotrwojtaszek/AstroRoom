using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsteltionLOD : MonoBehaviour
{
    public Mesh lowDetail;
    public Mesh highDetail;
    public Material materialLowDetail;
    public Material materialHighDetail;

    public void Start()
    {
        GetComponentInParent<ConstelationCustomLOD>().onCloseLOD += CloseLOD;
        GetComponentInParent<ConstelationCustomLOD>().onFarLOD += FarLOD;

    }

    private void FarLOD()
    {
        GetComponent<MeshFilter>().mesh = lowDetail;
        GetComponent<Renderer>().material = materialLowDetail;
    }

    private void CloseLOD()
    {
        GetComponent<MeshFilter>().mesh = highDetail;
        GetComponent<Renderer>().material = materialHighDetail;
    }


}
