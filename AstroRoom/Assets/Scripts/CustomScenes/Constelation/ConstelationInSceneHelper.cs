using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ConstelationInSceneHelper : MonoBehaviour
{
    public SOConstelationBase constelationPreset;
    /*    public int matrixSize;*/
    /*    public bool[,] adjMatrix;
        public Node[] nodes;*/

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (constelationPreset != null && constelationPreset.adjMatrix != null)
                for (int i = 0; i < constelationPreset.adjMatrix.GetLength(0); i++)
                {
                    Gizmos.DrawSphere(constelationPreset.nodes[i].position, .125f);
                    GUIStyle style = new GUIStyle();
                    style.fontStyle = FontStyle.Bold;
                    style.normal.textColor = Color.red;
                    style.fontSize = 20;
                    style.alignment = TextAnchor.MiddleCenter;
                    UnityEditor.Handles.Label(constelationPreset.nodes[i].position + new Vector3(0f, -.2f), "ID: "+i,style);
                }


        // Draw a yellow sphere at the transform's position
    }

    /*    public void Save()
        {
            constelationPreset.adjMatrix = adjMatrix;
            constelationPreset.nodes = nodes;
        }*/
}
