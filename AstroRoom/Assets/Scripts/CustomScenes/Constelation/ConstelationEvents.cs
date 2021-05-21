using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ConstelationEvents : MonoBehaviour
{
    private static ConstelationEvents instance;
    public static ConstelationEvents Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ConstelationEvents>();
            return instance;
        }
    }

    public UnityAction onSelected;
    public UnityAction onSkyPosition;
    public UnityAction onProgressReset;
}
