using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ConstelationEvents : MonoBehaviour
{

    public static ConstelationEvents current;

    private void Awake()
    {
        current = this;
    }

    private List<int> selected = new List<int>();

    public event Action<int> onSocketTriggerEnter;
    public void SocketTriggerEnter(int id)
    {
        if (onSocketTriggerEnter != null)
            onSocketTriggerEnter(id);
/*        if (selected.Contains(id))
            selected.Remove(id);
        if (selected.Count == 2)
            selected.RemoveAt(0);
        selected.Add(id);*/

    }

    public event Action<int> onSocketTriggerExit;
    public void SocketTriggerExit(int id)
    {
        if (onSocketTriggerExit != null)
            onSocketTriggerExit(id);
    }

/*    public event Action<int> onSocketSelect;
    private List<int> selected = new List<int>();
    public void SocketSelect(int id)
    {
        if (onSocketSelect != null)

            onSocketSelect(id);
    }*/
}
