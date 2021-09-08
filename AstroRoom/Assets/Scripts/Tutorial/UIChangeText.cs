using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIChangeText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI proUGUI;


    public void ChangeText(string description)
    {
        proUGUI.text = description;
    }
}
