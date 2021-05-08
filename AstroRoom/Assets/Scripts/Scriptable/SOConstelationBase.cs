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
public class Node
{
    public Vector3 position;
    public float size;
    public Node(Vector3 _position, float _size)
    {
        position = _position;
        size = _size;

    }
}