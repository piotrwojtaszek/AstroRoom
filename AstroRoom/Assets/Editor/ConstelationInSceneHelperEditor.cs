using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ConstelationInSceneHelper))]
public class ConstelationInSceneHelperEditor : Editor
{

    public int tmpMatrixSize;
    SerializedProperty constelationPreset;
    int id_1 = -1;
    int id_2 = -1;
    int checkId;
    void OnEnable()
    {
        constelationPreset = serializedObject.FindProperty("constelationPreset");
    }
    public override void OnInspectorGUI()
    {
        ConstelationInSceneHelper baseScript = (ConstelationInSceneHelper)target;

        EditorGUILayout.PropertyField(constelationPreset, new GUIContent("Constelation preset"));
        serializedObject.ApplyModifiedProperties();
        if (baseScript.constelationPreset == null)
            return;

        if (baseScript.constelationPreset.adjMatrix == null)
            baseScript.constelationPreset.adjMatrix = new bool[0, 0];

        if (baseScript.constelationPreset.adjMatrix.GetLength(0) == 0)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("How many nodes?");

            tmpMatrixSize = EditorGUILayout.IntField(tmpMatrixSize);
            if (GUILayout.Button("Confirm"))
            {

                /*              baseScript.constelationPreset.matrixSize = tmpMatrixSize;*/
                baseScript.constelationPreset.adjMatrix = new bool[tmpMatrixSize, tmpMatrixSize];
                baseScript.constelationPreset.nodes = new Node[tmpMatrixSize];
                for (int i = 0; i < baseScript.constelationPreset.nodes.Length; i++)
                {
                    Node node = new Node(new Vector3(i, 1f));
                    baseScript.constelationPreset.nodes[i] = node;
                }
            }
            GUILayout.EndHorizontal();
        }

        if (baseScript.constelationPreset.adjMatrix.GetLength(0) > 0)
        {
            GUILayout.BeginHorizontal();
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;

            GUILayout.Label(" ", GUILayout.Width(30));
            for (int i = 0; i < baseScript.constelationPreset.adjMatrix.GetLength(0); i++)
            {
                GUILayout.Label(i.ToString(), GUILayout.Width(29));
            }
            GUILayout.EndHorizontal();
            for (int i = 0; i < baseScript.constelationPreset.adjMatrix.GetLength(0); i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(i.ToString(), GUILayout.Width(30));
                for (int j = 0; j < baseScript.constelationPreset.adjMatrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        GUIStyle label = new GUIStyle();
                        label.fixedWidth = 30;
                        GUILayout.Label("", label);
                    }
                    else
                    {
                        baseScript.constelationPreset.adjMatrix[i, j] = EditorGUILayout.Toggle(baseScript.constelationPreset.adjMatrix[i, j], GUILayout.Width(30));
                    }
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.Space(20);
            GUILayout.BeginHorizontal();
            GUILayout.Label("ID:");
            id_1 = EditorGUILayout.IntField(id_1);
            GUILayout.Label("<======>");
            id_2 = EditorGUILayout.IntField(id_2);
            GUILayout.EndHorizontal();
            if (IsNodesExists(baseScript.constelationPreset, id_1, id_2))
                if (GUILayout.Button("Make connection"))
                {
                    baseScript.constelationPreset.adjMatrix[id_1, id_2] = true;
                    baseScript.constelationPreset.adjMatrix[id_2, id_1] = true;
                }

            GUILayout.Space(20);
            GUILayout.BeginHorizontal();
            GUILayout.Label("ID to check:");
            checkId = EditorGUILayout.IntField(checkId);
            if (GUILayout.Button("Connection from node"))
            {
                string temp = "Checked:  ";
                for (int i = 0; i < baseScript.constelationPreset.adjMatrix.GetLength(0); i++)
                {
                    temp += baseScript.constelationPreset.adjMatrix[checkId, i] + " ";
                }
                Debug.Log(temp);
            }
            GUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }
    private void OnSceneGUI()
    {
        ConstelationInSceneHelper baseScript = (ConstelationInSceneHelper)target;
        if (baseScript.constelationPreset == null || baseScript.constelationPreset.adjMatrix == null)
            return;
        if (baseScript.constelationPreset.nodes.Length == 0)
            return;

        foreach (Node node in baseScript.constelationPreset.nodes)
        {
            node.position = Handles.PositionHandle(node.position, Quaternion.identity);
        }
    }

    bool IsNodesExists(SOConstelationBase preset, int _id_1, int _id_2)
    {
        if (_id_1 >= preset.nodes.Length || _id_2 >= preset.nodes.Length || _id_1 < 0 || _id_2 < 0 || id_1 == id_2)
            return false;
        return true;
    }
}
