using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SimControllerEvents : MonoBehaviour
{
    private static SimControllerEvents _instance;
    public static SimControllerEvents Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SimControllerEvents>();
            }

            return _instance;
        }
    }
    public UnityAction onChangeMode;

    public void OnChangeModeTrigger() => onChangeMode?.Invoke();
}
