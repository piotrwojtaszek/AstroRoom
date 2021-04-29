using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Constelation", menuName = "Extended/Constelation")]
public class SOConstelationBase : ScriptableObject
{
    public List<Node> nodes = new List<Node>();
    public List<Edge> edges = new List<Edge>();


    #region Editor Window Stuff
    public void AddNode(Vector3 _position, GameObject prefab)
    {
        nodes.Add(new Node(_position));
        GameObject socket = Instantiate(prefab, _position, Quaternion.identity);
        socket.GetComponent<ConstelationSocket>().node = nodes[nodes.Count - 1];
        Debug.Log("Add node");
    }

    public void RemoveNode(GameObject toRemove)
    {
        int edgeIdToRemove = -1;
        for (int i = 0; i < edges.Count; i++)
        {
            if (edges[i].point_1 == toRemove.GetComponent<ConstelationSocket>().node || edges[i].point_2 == toRemove.GetComponent<ConstelationSocket>().node)
            {
                edgeIdToRemove = i;
            }
        }
        if (edgeIdToRemove != -1)
            edges.RemoveAt(edgeIdToRemove);
        CheckConknection(toRemove.GetComponent<ConstelationSocket>().node);
        nodes.Remove(toRemove.GetComponent<ConstelationSocket>().node);
        DestroyImmediate(toRemove);

    }

    public void AddEdge(Node _point_1, Node _point_2, GameObject prefab)
    {
        Edge newEdge = new Edge(_point_1, _point_2);
        bool duplicate = false;
        foreach (Edge edge in edges)
        {
            if (edge.point_1 == newEdge.point_1 && edge.point_2 == newEdge.point_2)
            {
                duplicate = true;
                return;
            }
        }
        if (duplicate)
            return;


        edges.Add(newEdge);
        GameObject edgeObject = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        edgeObject.GetComponent<ConstelationEdgeDebug>().edge = newEdge;
    }

    public void CheckConknection(Node _node)
    {
        GameObject[] lines = GameObject.FindGameObjectsWithTag("DebugEdge");
        foreach (GameObject edgeObj in lines)
        {
            ConstelationEdgeDebug edge = edgeObj.GetComponent<ConstelationEdgeDebug>();

            if (edge.edge.point_1 == _node || edge.edge.point_2 == _node)
            {
                edges.Remove(edge.edge);
                DestroyImmediate(edgeObj);
            }
        }
    }

    #endregion
}
[System.Serializable]
public class Edge
{
    public Node point_1;
    public Node point_2;

    public Edge(Node _point_1, Node _point_2)
    {
        point_1 = _point_1;
        point_2 = _point_2;
    }

}
[System.Serializable]
public class Node
{
    public Vector3 position;
    public Node(Vector3 _position)
    {
        position = _position;

    }
}