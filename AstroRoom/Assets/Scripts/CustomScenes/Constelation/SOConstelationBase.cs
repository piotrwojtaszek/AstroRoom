using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Constelation", menuName = "Extended/Constelation")]
public class SOConstelationBase : ScriptableObject
{
    public List<Node> nodes = new List<Node>();
    public List<Edge> edges = new List<Edge>();

    public void AddNode(Vector3 _position)
    {
        nodes.Add(new Node(_position));

        Debug.Log("Add node");
    }

    public void RemoveNode(int id)
    {
        /*        foreach(Edge edge in edges)
                {
                    if(edge.point_1 == node.id || edge.point_2 == node.id)
                    {
                        edges.Remove(edge);
                    }
                }*/

        int idToRemove = -1;
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].id == id)
                idToRemove = i;
        }
        if (idToRemove != -1)
            nodes.RemoveAt(idToRemove);

        Debug.Log("Remove node");
    }

}
[System.Serializable]
public class Edge
{
    public static int counter;
    public int id;
    public int point_1;
    public int point_2;

    public Edge()
    {
        this.id = counter;
        counter++;
    }

    public void GetPositions(List<Node> nodes, out Vector3 pos1, out Vector3 pos2)
    {
        pos1 = Vector3.zero;
        pos2 = Vector3.zero;

        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].id == point_1)
            {
                pos1 = nodes[i].position;
            }

            if (nodes[i].id == point_2)
            {
                pos2 = nodes[i].position;
            }
        }
    }
}
[System.Serializable]
public class Node
{
    public static int counter;
    public int id;
    public Vector3 position;
    /*    public List<Edge> edges;*/
    public Node()
    {
        this.position = Vector3.one;
        /*        this.edges = new List<Edge>();*/
        this.id = counter;
        counter++;
        Debug.Log("Counter: " + counter);
    }

    public Node(Vector3 _position)
    {
        this.position = _position;
        /*        this.edges = new List<Edge>();*/
        this.id = counter;
        counter++;
    }
}