using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Constelation",menuName ="Extended/Constelation")]
public class SOConstelationBase : ScriptableObject
{
    public List<Node> nodes = new List<Node>();
    public List<Edge> edges = new List<Edge>();

    public void AddNode(Vector2 _position)
    {
        nodes.Add(new Node(_position));

        Debug.Log("Add node");
    }

    public void RemoveNode(Node node)
    {
        foreach(Edge edge in edges)
        {
            if(edge.to == node || edge.from==node)
            {
                edges.Remove(edge);
            }
        }

        nodes.Remove(node);

        Debug.Log("Remove node");
    }
    
}

[System.Serializable]
public class Edge
{
    public Node from;
    public Node to;
}
[System.Serializable]
public class Node
{
    public Vector3 position;
    [HideInInspector]
    public List<Edge> edges;
    public Node()
    {
        this.position = Vector3.one;
        this.edges = new List<Edge>();
    }

    public Node(Vector3 _position)
    {
        this.position = _position;
        this.edges = new List<Edge>();
    }
}