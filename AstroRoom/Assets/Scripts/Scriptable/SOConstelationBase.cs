using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Constelation", menuName = "Extended/Constelation")]
public class SOConstelationBase : ScriptableObject
{
    public string conName;
    public bool[] adjMatrix;
    public Node[] nodes;
    public int size;
}
[System.Serializable]
public class Edge
{
    public int i_1;
    public int j_1;

    public int i_2;
    public int j_2;

}
[System.Serializable]
public class Matrix
{
    public bool content;
    public Matrix(bool _value)
    {
        content = _value;
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