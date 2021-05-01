using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ConstelationInSceneHelper))]
public class ConstelationInSceneHelperEditor : Editor
{

    public int tmpMatrixSize;
    SerializedProperty constelationPreset;

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

        if (baseScript.constelationPreset.adjMatrix != null)
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
        }



        serializedObject.ApplyModifiedProperties();
    }
    private void OnSceneGUI()
    {
        ConstelationInSceneHelper baseScript = (ConstelationInSceneHelper)target;
        if (baseScript.constelationPreset == null || baseScript.constelationPreset.nodes.Length == 0)
            return;
        foreach (Node node in baseScript.constelationPreset.nodes)
        {
            node.position = Handles.PositionHandle(node.position, Quaternion.identity);
        }


    }

    /*    private void Save(ConstelationInSceneHelper constelationInSceneHelper)
        {
            constelationInSceneHelper.constelationPreset.adjMatrix
        }*/

}
