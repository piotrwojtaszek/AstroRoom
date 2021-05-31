using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class ConstelationInSceneHelper : MonoBehaviour
{
    public SOConstelationBase constelationPreset;
    public Vector3 size = new Vector3(5f, 2f);
    /*    public int matrixSize;*/
    /*    public bool[,] adjMatrix;
        public Node[] nodes;*/

    void OnDrawGizmos()
    {
        /*        Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
                Gizmos.DrawCube(new Vector3(0, 1f), new Vector3(4f, 1.5f));

                Gizmos.color = new Color(0.9f, 0.8f, 0f, 0.15f);
                Gizmos.DrawCube(new Vector3(2.75f, 1f), new Vector3(1.5f, 1.5f));
                Gizmos.DrawCube(new Vector3(-2.75f, 1f), new Vector3(1.5f, 1.5f));
                Gizmos.color = new Color(1f, 0f, 0f, 0.15f);
                Gizmos.DrawCube(new Vector3(0f, 0f), new Vector3(7f, .5f));
                Gizmos.DrawCube(new Vector3(0f, 2f), new Vector3(7f, .5f));*/
        size = new Vector3(10f, 3f);
        Gizmos.color = new Color(0.3f, .3f, 1f, 0.4f);
        Gizmos.DrawCube(transform.position, size);
        Gizmos.color = new Color(1f, 0, 0, 0.4f);
        Gizmos.DrawCube(transform.position - Vector3.up * 2f, new Vector3(10f, 1f));

        Gizmos.color = Color.yellow;
        if (constelationPreset != null && constelationPreset.adjMatrix != null)
            for (int i = 0; i < constelationPreset.size; i++)
            {
                Gizmos.DrawSphere(constelationPreset.nodes[i].position + transform.position, constelationPreset.nodes[i].size / 2f);
                GUIStyle style = new GUIStyle();
                style.fontStyle = FontStyle.Bold;
                style.normal.textColor = Color.red;
                style.fontSize = 20;
                style.alignment = TextAnchor.MiddleCenter;
#if UNITY_EDITOR
                UnityEditor.Handles.Label(constelationPreset.nodes[i].position + new Vector3(0f, -.2f) + transform.position, "ID: " + i, style);
#endif
            }

        if (constelationPreset != null && constelationPreset.adjMatrix != null)
            for (int i = 0; i < constelationPreset.size; i++)
                for (int j = i; j < constelationPreset.size; j++)
                    if (constelationPreset.adjMatrix[i * constelationPreset.size + j] == true)
                        Gizmos.DrawLine(constelationPreset.nodes[i].position + transform.position, constelationPreset.nodes[j].position + transform.position);
        if (constelationPreset != null)
        {
            GUIStyle style = new GUIStyle();
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.white;
            style.fontSize = 30;
            style.alignment = TextAnchor.MiddleCenter;
#if UNITY_EDITOR
            UnityEditor.Handles.Label(transform.position + new Vector3(0f, 2.5f), constelationPreset.conName, style);
#endif
        }


    }
}
