using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[ExecuteAlways]
public class ConstelationNodeDebug : MonoBehaviour
{
    public SOConstelationBase constelationBase;
    private void OnEnable()
    {
        Debug.Log("Created");
    }

    public void CreateNode(Vector3 position, SOConstelationBase _constelationBase)
    {
   /*     node = new Node(position);*/

        constelationBase = _constelationBase;
    }
    private void Update()
    {
/*        node.position = transform.position;*/
/*        int index = constelationBase.nodes.IndexOf(node);
        constelationBase.nodes[index].position = transform.localPosition;*/
    }


/*    private void OnDisable()
    {
        constelationBase.nodes.Remove(node);
        Debug.Log("Destroyed");
    }*/
}
