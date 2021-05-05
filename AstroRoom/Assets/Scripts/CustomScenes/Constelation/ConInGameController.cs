using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class ConInGameController : MonoBehaviour
{
    public SOConstelationBase constelationPreset;
    string nameee;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (constelationPreset != null && constelationPreset.adjMatrix != null)
            for (int i = 0; i < constelationPreset.size; i++)
            {
                Gizmos.DrawSphere(constelationPreset.nodes[i].position + transform.position, .1f);
                GUIStyle style = new GUIStyle();
                style.fontStyle = FontStyle.Bold;
                style.normal.textColor = Color.red;
                style.fontSize = 20;
                style.alignment = TextAnchor.MiddleCenter;
                UnityEditor.Handles.Label(constelationPreset.nodes[i].position + new Vector3(0f, -.2f) + transform.position, "ID: " + i, style);
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
            UnityEditor.Handles.Label(transform.position + new Vector3(0f, 2.5f), constelationPreset.conName, style);
        }
    }
}
