using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
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
    public UnityAction onComplete;
    public UnityAction onAlmostComplete;
    public UnityAction toHide;
    public UnityAction makeNormal;
    public Func<Sprite> currentSelected;
}
