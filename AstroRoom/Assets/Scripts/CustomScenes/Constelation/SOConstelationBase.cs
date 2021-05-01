using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Constelation", menuName = "Extended/Constelation")]
public class SOConstelationBase : ScriptableObject
{
    public bool[,] adjMatrix = new bool[0,0];
    public Node[] nodes = new Node[0];
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
public class Node
{
    public Vector3 position;
    public Node(Vector3 _position)
    {
        position = _position;
    }
}