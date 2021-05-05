using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ConstelationInSceneHelper))]
public class ConstelationInSceneHelperEditor : Editor
{
    SerializedProperty constelationPreset;
    int id_1 = 0;
    int id_2 = 0;
    int checkId;
    bool displayOpt = false;
    void OnEnable()
    {
        constelationPreset = serializedObject.FindProperty("constelationPreset");

    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ConstelationInSceneHelper baseScript = (ConstelationInSceneHelper)target;

        EditorGUILayout.PropertyField(constelationPreset, new GUIContent("Constelation preset"));
        serializedObject.ApplyModifiedProperties();
        if (baseScript.constelationPreset == null)
            return;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Constelation name");
        baseScript.constelationPreset.conName = EditorGUILayout.TextField(baseScript.constelationPreset.conName);
        EditorGUILayout.EndHorizontal();

        /*        if (baseScript.constelationPreset.adjMatrix == null)
                {
                    baseScript.constelationPreset.adjMatrix = new bool[0, 0];

                }*/


        if (baseScript.constelationPreset.adjMatrix == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("How many nodes?");

            baseScript.constelationPreset.size = EditorGUILayout.IntField(baseScript.constelationPreset.size);
            if (GUILayout.Button("Confirm"))
            {

                baseScript.constelationPreset.nodes = new Node[baseScript.constelationPreset.size];
                baseScript.constelationPreset.adjMatrix = new bool[baseScript.constelationPreset.size * baseScript.constelationPreset.size];
                for (int i = 0; i < baseScript.constelationPreset.nodes.Length; i++)
                {
                    Node node = new Node(new Vector3(i, 1f));
                    baseScript.constelationPreset.nodes[i] = node;
                }
                serializedObject.ApplyModifiedProperties();
            }

            GUILayout.EndHorizontal();
        }
        if (baseScript.constelationPreset.adjMatrix == null)
        {
            return;
        }

        GUILayout.BeginHorizontal();
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;

        GUILayout.Label(" ", GUILayout.Width(30));
        for (int i = 0; i < baseScript.constelationPreset.size - 1; i++)
        {
            GUILayout.Label(i.ToString(), GUILayout.Width(29));
        }
        GUILayout.EndHorizontal();

        if (baseScript.constelationPreset.adjMatrix.Length > 0)
        {
            for (int i = 0; i < baseScript.constelationPreset.size; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(i.ToString(), GUILayout.Width(30));
                for (int j = 0; j < baseScript.constelationPreset.size; j++)
                {
                    if (i == j)
                    {
                        GUIStyle label = new GUIStyle();
                        label.fixedWidth = 30;
                        GUILayout.Label("", label);
                    }
                    else
                    {
                        int row = baseScript.constelationPreset.size * i;
                        baseScript.constelationPreset.adjMatrix[row + j] = EditorGUILayout.Toggle(baseScript.constelationPreset.adjMatrix[row + j], GUILayout.Width(30));
                        int inverted = baseScript.constelationPreset.size * j;
                        baseScript.constelationPreset.adjMatrix[inverted+i] = baseScript.constelationPreset.adjMatrix[row + j];
                        serializedObject.ApplyModifiedProperties();
                    }
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(20);
            if (displayOpt == false)
                if (GUILayout.Button("SHOW MORE"))
                {
                    displayOpt = true;
                }

            if (displayOpt)
            {
                GUIStyle connectionStyle = new GUIStyle();
                connectionStyle.alignment = TextAnchor.MiddleCenter;
                connectionStyle.normal.textColor = Color.white;
                GUILayout.BeginHorizontal();
                GUILayout.BeginVertical();
                GUILayout.Label("ID", connectionStyle);
                id_1 = EditorGUILayout.IntField(id_1);
                GUILayout.EndVertical();
                GUILayout.BeginVertical();
                GUILayout.Label(" ");
                GUILayout.Label("<--->");
                GUILayout.EndVertical();
                GUILayout.BeginVertical();
                GUILayout.Label("ID", connectionStyle);
                id_2 = EditorGUILayout.IntField(id_2);
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                if (IsNodesExists(baseScript.constelationPreset, id_1, id_2))
                    if (GUILayout.Button("Make connection"))
                    {
                        baseScript.constelationPreset.adjMatrix[id_1 + 1 * id_2] = true;
                        baseScript.constelationPreset.adjMatrix[id_2 + 1 * id_1] = true;
                    }

                if (IsNodesExists(baseScript.constelationPreset, id_1, id_2))
                    if (GUILayout.Button("Delete connection"))
                    {
                        baseScript.constelationPreset.adjMatrix[id_1 + 1 * id_2] = false;
                        baseScript.constelationPreset.adjMatrix[id_2 + 1 * id_1] = false;
                    }
                GUILayout.EndHorizontal();

                GUILayout.Space(20);

                if (GUILayout.Button("COLLAPSE"))
                {
                    displayOpt = false;
                }
            }


            /* GUILayout.Space(20);
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
             GUILayout.EndHorizontal();*/
        }

        if (GUILayout.Button("Show matrix"))
        {
            ConDataSave.Save();
        }
        serializedObject.ApplyModifiedProperties();
        if (GUI.changed)
        {
            string path = AssetDatabase.GetAssetPath(baseScript.constelationPreset).ToString();

            SOConstelationBase temp = new SOConstelationBase();
            temp.adjMatrix = baseScript.constelationPreset.adjMatrix;
            temp.conName = baseScript.constelationPreset.conName;
            temp.nodes= baseScript.constelationPreset.nodes;
            temp.size = baseScript.constelationPreset.size;
            AssetDatabase.DeleteAsset(path);
            AssetDatabase.CreateAsset(temp, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            baseScript.constelationPreset = temp;
            EditorUtility.SetDirty(target);
            Debug.Log("CHANGED");
        }
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
