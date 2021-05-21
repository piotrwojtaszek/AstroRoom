using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsteltionLOD : MonoBehaviour
{
    public Mesh lowDetail;
    public Mesh highDetail;

    public void Start()
    {
        GetComponentInParent<ConstelationCustomLOD>().onCloseLOD += CloseLOD;
        GetComponentInParent<ConstelationCustomLOD>().onFarLOD += FarLOD;

    }

    private void FarLOD()
    {
        GetComponent<MeshFilter>().mesh = lowDetail;
    }

    private void CloseLOD()
    {
        GetComponent<MeshFilter>().mesh = highDetail;
    }


}
