using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UITriggerCanvas : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI proUGUI;


    public void OnHoverEnter(string description)
    {
        proUGUI.text = description;
    }

    public void OnHoverExit(string description)
    {
        proUGUI.text = description;
    }
}
