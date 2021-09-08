using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISocketTutorial : MonoBehaviour
{
    private Material baseMaterial;

    void Start()
    {
        baseMaterial = GetComponent<Renderer>().material;
    }

    public void OnSelectEnter()
    {
        baseMaterial.color = Color.red;
    }

    public void OnSelectExit()
    {
        baseMaterial.color = Color.white;
    }
}
