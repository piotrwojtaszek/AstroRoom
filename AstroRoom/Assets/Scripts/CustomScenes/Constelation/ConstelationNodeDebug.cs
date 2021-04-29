using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class ConstelationNodeDebug : MonoBehaviour
{
    public Node node;
    public SOConstelationBase constelationBase;
    private void Update()
    {
        int index = constelationBase.nodes.BinarySearch(node);
        constelationBase.nodes[index].position = transform.localPosition;
    }
}
