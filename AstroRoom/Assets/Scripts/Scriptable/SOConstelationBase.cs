using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Constelation", menuName = "Extended/Constelation")]
public class SOConstelationBase : ScriptableObject
{
    public string ConName { get { return conName; } set { conName = value; } }
    [SerializeField]
    public string conName = "NEW";
    public bool[] AdjMatrix { get { return adjMatrix; } set { adjMatrix = value; } }
    [SerializeField]
    private bool[] adjMatrix;
    public Node[] Nodes { get { return nodes; } set { nodes = value; } }
    [SerializeField]
    private Node[] nodes;
    public int Size { get { return size; } set { size = value; } }
    [SerializeField]
    private int size;
        private void OnEnable()
        {
            hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
    /*    public int matrixSize;*/
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