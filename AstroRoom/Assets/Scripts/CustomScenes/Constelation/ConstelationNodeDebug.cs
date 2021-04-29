using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[ExecuteAlways]
public class ConstelationNodeDebug : MonoBehaviour
{
    public Node node;
    public SOConstelationBase constelationBase;
    private void Update()
    {
        int index = constelationBase.nodes.IndexOf(node);
        constelationBase.nodes[index].position = transform.localPosition;
    }
}
