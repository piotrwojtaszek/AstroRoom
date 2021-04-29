using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ConstelationSocket : MonoBehaviour
{
    public Node node;
    private void Update()
    {
        node.position = transform.localPosition;
    }
}
