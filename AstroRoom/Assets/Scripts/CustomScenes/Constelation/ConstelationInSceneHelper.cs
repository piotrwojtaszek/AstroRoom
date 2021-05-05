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
        Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
        Gizmos.DrawCube(new Vector3(0, 1f), new Vector3(4f, 1.5f));

        Gizmos.color = new Color(0.9f, 0.8f, 0f, 0.15f);
        Gizmos.DrawCube(new Vector3(2.75f, 1f), new Vector3(1.5f, 1.5f));
        Gizmos.DrawCube(new Vector3(-2.75f, 1f), new Vector3(1.5f, 1.5f));
        Gizmos.color = new Color(1f, 0f, 0f, 0.15f);
        Gizmos.DrawCube(new Vector3(0f, 0f), new Vector3(7f, .5f));
        Gizmos.DrawCube(new Vector3(0f, 2f), new Vector3(7f, .5f));

        Gizmos.color = Color.yellow;
        if (constelationPreset != null && constelationPreset.AdjMatrix != null)
            for (int i = 0; i < constelationPreset.Size; i++)
            {
                Gizmos.DrawSphere(constelationPreset.Nodes[i].position, .1f);
                GUIStyle style = new GUIStyle();
                style.fontStyle = FontStyle.Bold;
                style.normal.textColor = Color.red;
                style.fontSize = 20;
                style.alignment = TextAnchor.MiddleCenter;
                UnityEditor.Handles.Label(constelationPreset.Nodes[i].position + new Vector3(0f, -.2f), "ID: " + i, style);
            }

        if (constelationPreset != null && constelationPreset.AdjMatrix != null)
            for (int i = 0; i < constelationPreset.Size; i++)
                for (int j = i; j < constelationPreset.Size; j++)
                    if (constelationPreset.AdjMatrix[i*constelationPreset.Size+ j] == true)
                        Gizmos.DrawLine(constelationPreset.Nodes[i].position, constelationPreset.Nodes[j].position);
        if (constelationPreset != null)
        {
            GUIStyle style = new GUIStyle();
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.white;
            style.fontSize = 30;
            style.alignment = TextAnchor.MiddleCenter;
            UnityEditor.Handles.Label(transform.position + new Vector3(0f, 2.5f), constelationPreset.ConName,style);
        }


    }
}
