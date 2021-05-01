using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ConstelationInSceneHelper : MonoBehaviour
{
    public SOConstelationBase constelationPreset;
    public int matrixSize;
    public bool[,] adjMatrix;
    public Node[] nodes;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < nodes.Length; i++)
        {
            Gizmos.DrawSphere(nodes[i].position, .125f);
        }
        // Draw a yellow sphere at the transform's position
    }

    public void Save()
    {
        constelationPreset.adjMatrix = adjMatrix;
        constelationPreset.nodes = nodes;
    }
}
