using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RestartAllObjects : MonoBehaviour
{
    public static RestartAllObjects instance;
    public static RestartAllObjects Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<RestartAllObjects>();
            return instance;
        }
    }

    public UnityAction onReset;
    // Start is called before the first frame update
    public void Reset()
    {
        onReset?.Invoke();
    }
}
