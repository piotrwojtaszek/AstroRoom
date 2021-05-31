using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ConstelationInSceneHelper))]
public class ConstelationInSceneHelperEditor : Editor
{
    SerializedProperty constelationPreset;
    bool gizmos = true;
    Vector3 snap;

    void OnEnable()
    {
        constelationPreset = serializedObject.FindProperty("constelationPreset");

    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        ConstelationInSceneHelper baseScript = (ConstelationInSceneHelper)target;

        /*EditorGUILayout.LabelField("Constelation preset", GUILayout.Width(300));*/
        EditorGUILayout.PropertyField(constelationPreset);
        serializedObject.ApplyModifiedProperties();
        if (baseScript.constelationPreset == null)
            return;

        GUILayout.Space(15);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("NAZWA GWIAZDOZBIORU");
        baseScript.constelationPreset.conName = EditorGUILayout.TextField(baseScript.constelationPreset.conName);
        EditorGUILayout.EndHorizontal();

        if (baseScript.constelationPreset.adjMatrix == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("ILOå∆ GWIAZD");

            baseScript.constelationPreset.size = EditorGUILayout.IntField(baseScript.constelationPreset.size);
            if (GUILayout.Button("POTWIERDè"))
            {

                baseScript.constelationPreset.nodes = new Node[baseScript.constelationPreset.size];
                baseScript.constelationPreset.adjMatrix = new bool[baseScript.constelationPreset.size * baseScript.constelationPreset.size];
                for (int i = 0; i < baseScript.constelationPreset.nodes.Length; i++)
                {
                    Node node = new Node(new Vector3(i, 1f), 0.25f);
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

        GUILayout.Space(15);
        EditorGUILayout.LabelField("MACIERZ S•SIEDZTWA");

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
            for (int i = baseScript.constelationPreset.size - 1; i > 0; i--)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(i.ToString(), GUILayout.Width(30));
                for (int j = 0; j < i; j++)
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
                        baseScript.constelationPreset.adjMatrix[inverted + i] = baseScript.constelationPreset.adjMatrix[row + j];
                        serializedObject.ApplyModifiedProperties();
                    }
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(30);
            /*                GUIStyle connectionStyle = new GUIStyle();
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
            *//*                if (IsNodesExists(baseScript.constelationPreset, id_1, id_2))
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
                                }*//*
                            GUILayout.EndHorizontal();*/

            /*            GUILayout.Label("Stars name");
                        EditorGUILayout.Space(10);
                        for (int i = 0; i < baseScript.constelationPreset.size; i++)
                        {
                            GUILayout.BeginHorizontal();
                            GUILayout.Label(i.ToString(), GUILayout.Width(30));
                            baseScript.constelationPreset.nodes[i].starName = EditorGUILayout.TextField(baseScript.constelationPreset.nodes[i].starName, GUILayout.MaxWidth(400));
                            GUILayout.EndHorizontal();
                        }*/

            GUILayout.Space(30);
            GUILayout.Label("WielkoúÊ gwiazd");
            EditorGUILayout.Space(10);
            for (int i = 0; i < baseScript.constelationPreset.size; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(i.ToString(), GUILayout.Width(30));
                baseScript.constelationPreset.nodes[i].size = EditorGUILayout.Slider(baseScript.constelationPreset.nodes[i].size, 0.1f, .75f, GUILayout.MaxWidth(400));
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(30);
            GUILayout.Label("Pozycje gwiazd");
            EditorGUILayout.Space(10);
            for (int i = 0; i < baseScript.constelationPreset.size; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(i.ToString(), GUILayout.Width(30));
                baseScript.constelationPreset.nodes[i].position.x = EditorGUILayout.FloatField(baseScript.constelationPreset.nodes[i].position.x, GUILayout.MaxWidth(100));
                baseScript.constelationPreset.nodes[i].position.y = EditorGUILayout.FloatField(baseScript.constelationPreset.nodes[i].position.y, GUILayout.MaxWidth(100));
                baseScript.constelationPreset.nodes[i].position.z = EditorGUILayout.FloatField(baseScript.constelationPreset.nodes[i].position.z, GUILayout.MaxWidth(100));
                GUILayout.EndHorizontal();

            }
            GUILayout.Space(30);
            GUILayout.Label("Pozycja gwiazdozbioru");
            EditorGUILayout.Space(10);

            GUILayout.BeginHorizontal();
            GUILayout.Label("WysokoúÊ nad horyzontem", GUILayout.Width(30));
            baseScript.constelationPreset.skyPosition.x = EditorGUILayout.Slider(baseScript.constelationPreset.skyPosition.x, -90f, 90f, GUILayout.MaxWidth(400));
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label("Pozycja w poziomie", GUILayout.Width(30));
            baseScript.constelationPreset.skyPosition.y = EditorGUILayout.Slider(baseScript.constelationPreset.skyPosition.y, -180f, 180f, GUILayout.MaxWidth(400));
            GUILayout.EndHorizontal();


            GUILayout.Space(30);
            GUILayout.Label("WielkoúÊ obrysu");
            GUILayout.BeginHorizontal();

            GUILayout.Label("Vector", GUILayout.MaxWidth(60));
            GUILayout.Label("X", GUILayout.MaxWidth(12));
            baseScript.constelationPreset.boundSize.x = EditorGUILayout.Slider(baseScript.constelationPreset.boundSize.x, 0.1f, 10f, GUILayout.MaxWidth(400));
            GUILayout.Label("Y", GUILayout.MaxWidth(12));
            baseScript.constelationPreset.boundSize.y = EditorGUILayout.Slider(baseScript.constelationPreset.boundSize.y, 0.1f, 10f, GUILayout.MaxWidth(400));
            GUILayout.EndHorizontal();
            GUILayout.Space(30);

            GUILayout.Label("årodek obrysu");
            GUILayout.BeginHorizontal();

            GUILayout.Label("Vector", GUILayout.MaxWidth(60));
            GUILayout.Label("X", GUILayout.MaxWidth(12));
            baseScript.constelationPreset.boundCenter.x = EditorGUILayout.Slider(baseScript.constelationPreset.boundCenter.x, -10f, 10f, GUILayout.MaxWidth(400));
            GUILayout.Label("Y", GUILayout.MaxWidth(12));
            baseScript.constelationPreset.boundCenter.y = EditorGUILayout.Slider(baseScript.constelationPreset.boundCenter.y, -10f, 10f, GUILayout.MaxWidth(400));
            GUILayout.EndHorizontal();
            GUILayout.Space(30);

            GUILayout.Label("PrzesuÒ wszystko");
            GUILayout.BeginHorizontal();

            GUILayout.Label("Vector", GUILayout.MaxWidth(60));
            GUILayout.Label("X", GUILayout.MaxWidth(12));
            snap.x = EditorGUILayout.FloatField(snap.x, GUILayout.MaxWidth(50));
            GUILayout.Label("Y", GUILayout.MaxWidth(12));
            snap.y = EditorGUILayout.FloatField(snap.y, GUILayout.MaxWidth(50));
            GUILayout.Label("Z", GUILayout.MaxWidth(12));
            snap.z = EditorGUILayout.FloatField(snap.z, GUILayout.MaxWidth(50));
            if (GUILayout.Button("RUSZ", GUILayout.MaxWidth(75)))
            {
                MoveAllStars(snap, baseScript);
            }

            GUILayout.EndHorizontal();

            GUILayout.Space(30);
            if (GUILayout.Button("UCHWYTY"))
            {
                gizmos = !gizmos;
            }
            GUILayout.Space(10);
            if (GUILayout.Button("ZAPISZ"))
            {
                string path = AssetDatabase.GetAssetPath(baseScript.constelationPreset).ToString();
                SOConstelationBase temp = ScriptableObject.CreateInstance<SOConstelationBase>();
                temp.adjMatrix = baseScript.constelationPreset.adjMatrix;
                temp.conName = baseScript.constelationPreset.conName;
                temp.nodes = baseScript.constelationPreset.nodes;
                temp.size = baseScript.constelationPreset.size;
                temp.skyPosition = baseScript.constelationPreset.skyPosition;
                temp.boundCenter = baseScript.constelationPreset.boundCenter;
                temp.boundSize = baseScript.constelationPreset.boundSize;
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.CreateAsset(temp, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                baseScript.constelationPreset = temp;
                EditorUtility.SetDirty(target);

            }
            GUILayout.Space(40);

            /*if (GUILayout.Button("RESET"))
            {
                baseScript.constelationPreset.adjMatrix = null;
                baseScript.constelationPreset.nodes = null;
                baseScript.constelationPreset.conName = null;
                baseScript.constelationPreset.size = 0;
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                EditorUtility.SetDirty(target);

            }*/
            GUILayout.Space(20);
        }


        if (GUI.changed)
        {
            /*            string path = AssetDatabase.GetAssetPath(baseScript.constelationPreset).ToString();
                        SOConstelationBase temp = ScriptableObject.CreateInstance<SOConstelationBase>();
                        temp.adjMatrix = baseScript.constelationPreset.adjMatrix;
                        temp.conName = baseScript.constelationPreset.conName;
                        temp.nodes = baseScript.constelationPreset.nodes;
                        temp.size = baseScript.constelationPreset.size;
                        AssetDatabase.DeleteAsset(path);
                        AssetDatabase.CreateAsset(temp, path);
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
                        baseScript.constelationPreset = temp;*/
            EditorUtility.SetDirty(target);
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
        Handles.DrawWireCube((Vector3)baseScript.constelationPreset.boundCenter + baseScript.transform.position, baseScript.constelationPreset.boundSize);
        if (gizmos)
        {
            foreach (Node node in baseScript.constelationPreset.nodes)
            {
                // w sumie to powinno byÊ node.position + transform.position, ale zrobi siÍ z teog nieskoÒcona pÍtla wiÍÊ poiwnno byÊ jakiúbufor vec3 temp = handles, a potem node.position = temp - transform.position;
                Vector3 buffor = Handles.PositionHandle(node.position + baseScript.transform.position, Quaternion.identity);
                node.position = buffor - baseScript.transform.position;
                Repaint();
            }
        }

    }

    /*    bool IsNodesExists(SOConstelationBase preset, int _id_1, int _id_2)
        {
            if (_id_1 >= preset.nodes.Length || _id_2 >= preset.nodes.Length || _id_1 < 0 || _id_2 < 0 || id_1 == id_2)
                return false;
            return true;
        }*/

    void MoveAllStars(Vector3 delta, ConstelationInSceneHelper baseScript)
    {
        for (int i = 0; i < baseScript.constelationPreset.size; i++)
        {
            baseScript.constelationPreset.nodes[i].position += delta;
        }
    }
}
