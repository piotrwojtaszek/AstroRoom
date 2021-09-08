using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ChangeColor : MonoBehaviour
{
    public void OnHoverEnter()
    {
        GetComponent<Renderer>().material.color = Color.yellow;   
    }
    public void OnHoverExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
