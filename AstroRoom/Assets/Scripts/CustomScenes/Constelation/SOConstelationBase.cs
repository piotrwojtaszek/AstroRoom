using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Constelation", menuName = "Extended/Constelation")]
public class SOConstelationBase : ScriptableObject
{
    public List<Node> nodes = new List<Node>();
    public List<Edge> edges = new List<Edge>();


    #region Game Scene Stuff




    #endregion

    #region Editor Window Stuff
    public void AddNode(GameObject prefab)
    {
        /*nodes.Add(new Node(Vector3.zero, this));*/
        GameObject socket = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        socket.GetComponent<ConstelationNodeDebug>().CreateNode(socket.transform.position, this);

    }

    public void RemoveNode(GameObject toRemove)
    {
/*        int edgeIdToRemove = -1;
        for (int i = 0; i < edges.Count; i++)
        {
            if (edges[i].point_1 == toRemove.GetComponent<ConstelationNodeDebug>().node || edges[i].point_2 == toRemove.GetComponent<ConstelationNodeDebug>().node)
            {
                edgeIdToRemove = i;
            }
        }
        if (edgeIdToRemove != -1)
            edges.RemoveAt(edgeIdToRemove);
        CheckConknection(toRemove.GetComponent<ConstelationNodeDebug>().node);
        nodes.Remove(toRemove.GetComponent<ConstelationNodeDebug>().node);*/
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

    public void RemoveEdge(Edge edge)
    {
        edges.Remove(edge);
    }

    public void CheckConknection(Node _node)
    {
        GameObject[] lines = GameObject.FindGameObjectsWithTag("DebugEdge");
        foreach (GameObject edgeObj in lines)
        {
            ConstelationEdgeDebug edge = edgeObj.GetComponent<ConstelationEdgeDebug>();

            if (edge.edge.point_1 == _node || edge.edge.point_2 == _node)
            {
                RemoveEdge(edge.edge);
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
/*    public SOConstelationBase constelationBase;*/
    public Node(Vector3 _position)
    {
        position = _position;
        /*constelationBase = _constelationBase;*/
    }
}