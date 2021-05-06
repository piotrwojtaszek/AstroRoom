using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ConstelationController : MonoBehaviour
{
    public static ConstelationController instance;
    public SOConstelationBase constelationPreset;
    public GameObject socket;
    public GameObject edge;


    private void Awake()
    {
        instance = this;
        int i = 0;
        foreach(Node node in constelationPreset.nodes)
        {
            GameObject nodeObj = Instantiate(socket, transform);
            nodeObj.transform.localPosition = node.position;
            nodeObj.GetComponent<ConstelationSocket>().id = i;
            i++;
        }
    }

    // musi byc jakas subskrypcja, po zape³nieniu socketa odzywa sie sprwdza czy jest juz po³¹æ¿enie


}
