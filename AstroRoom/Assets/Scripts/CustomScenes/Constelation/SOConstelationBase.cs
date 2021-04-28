using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Constelation", menuName = "Extended/Constelation")]
public class SOConstelationBase : ScriptableObject
{
    public Vector3 origin;
    public GameObject prefab;
    public List<Node> nodes = new List<Node>();
    public List<Edge> edges = new List<Edge>();

    public void AddNode(Vector3 _position)
    {
        nodes.Add(new Node(_position));
        GameObject socket = Instantiate(prefab, _position, Quaternion.identity);
        socket.GetComponent<ConstelationSocket>().node = nodes[nodes.Count - 1];
        Debug.Log("Add node");
    }

    public void RemoveNode(GameObject toRemove)
    {
        
        nodes.Remove(toRemove.GetComponent<ConstelationSocket>().node);
        DestroyImmediate(toRemove);
        Debug.Log("Destroy");
    }

}
[System.Serializable]
public class Edge
{
    public Node point_1;
    public Node point_2;
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