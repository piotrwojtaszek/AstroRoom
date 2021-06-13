using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ConstelationInSceneHelper))]
public class ConstelationInSceneHelperEditor : Editor
{
    SerializedProperty constelationPreset;
    bool matrixMode = true;
    int id_1, id_2;
    bool[] gizmosMode;
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


        if (gizmosMode == null || gizmosMode.Length != baseScript.constelationPreset.size)
        {
            gizmosMode = new bool[baseScript.constelationPreset.size];
            if (gizmosMode.Length > 0)
            {
                gizmosMode[0] = true;
            }
        }


        GUILayout.Space(15);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Nazwa gwiazdozbioru");
        baseScript.constelationPreset.conName = EditorGUILayout.TextField(baseScript.constelationPreset.conName);
        EditorGUILayout.EndHorizontal();

        if (baseScript.constelationPreset.adjMatrix == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("IloúÊ gwiazd");

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
                baseScript.constelationPreset.titleHeight = new Vector2(0f, 2.5f);
            }

            GUILayout.EndHorizontal();
        }
        if (baseScript.constelationPreset.adjMatrix == null)
        {
            return;
        }

        if (baseScript.constelationPreset.adjMatrix.Length > 0)
        {
            GUILayout.Space(15);
            if (GUILayout.Button("ZmieÒ tryb wprowadzania"))
            {
                matrixMode = !matrixMode;
            }

            if (matrixMode)
            {
                GUILayout.Space(15);
                EditorGUILayout.LabelField("Macierz sπsiedztwa");

                GUILayout.BeginHorizontal();
                GUIStyle style = new GUIStyle();
                style.alignment = TextAnchor.MiddleCenter;

                GUILayout.Label(" ", GUILayout.Width(30));
                for (int i = 0; i < baseScript.constelationPreset.size - 1; i++)
                {
                    GUILayout.Label(i.ToString(), GUILayout.Width(29));
                }
                GUILayout.EndHorizontal();

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
            }
            else
            {
                GUILayout.Space(15);
                GUIStyle style = new GUIStyle();
                style.alignment = TextAnchor.MiddleCenter;
                style.fixedWidth = 60;
                style.normal.textColor = Color.white;
                GUILayout.BeginHorizontal();
                id_1 = EditorGUILayout.IntField(id_1, GUILayout.MaxWidth(100));
                GUILayout.Label("<--->", style);
                id_2 = EditorGUILayout.IntField(id_2, GUILayout.MaxWidth(100));
                if (IsNodesExists(baseScript.constelationPreset, id_1, id_2))
                    if (GUILayout.Button("StwÛrz po≥πczenie"))
                    {
                        baseScript.constelationPreset.adjMatrix[id_1 + 1 * id_2] = true;
                        baseScript.constelationPreset.adjMatrix[id_2 + 1 * id_1] = true;
                        serializedObject.ApplyModifiedProperties();
                    }

                if (IsNodesExists(baseScript.constelationPreset, id_1, id_2))
                    if (GUILayout.Button("UsuÒ po≥πczenie"))
                    {
                        baseScript.constelationPreset.adjMatrix[id_1 + 1 * id_2] = false;
                        baseScript.constelationPreset.adjMatrix[id_2 + 1 * id_1] = false;
                        serializedObject.ApplyModifiedProperties();
                    }
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(30);
            GUILayout.Label("Pozycja i wielkoúÊ gwiazd");
            EditorGUILayout.Space(10);
            for (int i = 0; i < baseScript.constelationPreset.size; i++)
            {
                GUILayout.BeginHorizontal();

                if (gizmosMode.Length - 1 >= i)
                    gizmosMode[i] = EditorGUILayout.Toggle(gizmosMode[i], GUILayout.Width(30));

                GUILayout.Label(i.ToString(), GUILayout.Width(30));
                baseScript.constelationPreset.nodes[i].position.x = EditorGUILayout.FloatField(baseScript.constelationPreset.nodes[i].position.x, GUILayout.MaxWidth(90));
                baseScript.constelationPreset.nodes[i].position.y = EditorGUILayout.FloatField(baseScript.constelationPreset.nodes[i].position.y, GUILayout.MaxWidth(90));
                baseScript.constelationPreset.nodes[i].position.z = EditorGUILayout.FloatField(baseScript.constelationPreset.nodes[i].position.z, GUILayout.MaxWidth(90));
                baseScript.constelationPreset.nodes[i].size = EditorGUILayout.Slider(baseScript.constelationPreset.nodes[i].size, 0.1f, .75f, GUILayout.MaxWidth(400));
                GUILayout.EndHorizontal();
            }
            GUILayout.Space(30);
            GUILayout.Label("Pozycja konstelacji");
            EditorGUILayout.Space(10);

            GUILayout.BeginHorizontal();
            GUILayout.Label("X", GUILayout.Width(30));
            baseScript.constelationPreset.skyPosition.y = EditorGUILayout.Slider(baseScript.constelationPreset.skyPosition.y, -180f, 180f, GUILayout.MaxWidth(400));
            GUILayout.Label("Y", GUILayout.Width(30));
            baseScript.constelationPreset.skyPosition.x = EditorGUILayout.Slider(baseScript.constelationPreset.skyPosition.x, -90f, 90f, GUILayout.MaxWidth(400));
            GUILayout.EndHorizontal();


            GUILayout.Space(30);
            GUILayout.Label("WielkoúÊ obrysu");
            GUILayout.BeginHorizontal();

            GUILayout.Label("X", GUILayout.MaxWidth(30));
            baseScript.constelationPreset.boundSize.x = EditorGUILayout.Slider(baseScript.constelationPreset.boundSize.x, 0.1f, 10f, GUILayout.MaxWidth(400));
            GUILayout.Label("Y", GUILayout.MaxWidth(30));
            baseScript.constelationPreset.boundSize.y = EditorGUILayout.Slider(baseScript.constelationPreset.boundSize.y, 0.1f, 10f, GUILayout.MaxWidth(400));
            GUILayout.EndHorizontal();
            GUILayout.Space(30);

            GUILayout.Label("årodek obrysu");
            GUILayout.BeginHorizontal();

            GUILayout.Label("X", GUILayout.MaxWidth(30));
            baseScript.constelationPreset.boundCenter.x = EditorGUILayout.Slider(baseScript.constelationPreset.boundCenter.x, -10f, 10f, GUILayout.MaxWidth(400));
            GUILayout.Label("Y", GUILayout.MaxWidth(30));
            baseScript.constelationPreset.boundCenter.y = EditorGUILayout.Slider(baseScript.constelationPreset.boundCenter.y, -10f, 10f, GUILayout.MaxWidth(400));
            GUILayout.EndHorizontal();
            GUILayout.Space(30);

            GUILayout.Label("Pozycja napisu");
            GUILayout.BeginHorizontal();

            GUILayout.Label("X", GUILayout.MaxWidth(30));
            baseScript.constelationPreset.titleHeight.x = EditorGUILayout.Slider(baseScript.constelationPreset.titleHeight.x, -5f, 5f, GUILayout.MaxWidth(400));
            GUILayout.Label("Y", GUILayout.MaxWidth(30));
            baseScript.constelationPreset.titleHeight.y = EditorGUILayout.Slider(baseScript.constelationPreset.titleHeight.y, -1f, 7f, GUILayout.MaxWidth(400));
            GUILayout.EndHorizontal();
            GUILayout.Space(30);

            GUILayout.Label("PrzesuÒ gwiazdy");
            GUILayout.BeginHorizontal();

            GUILayout.Label("Wektor", GUILayout.MaxWidth(60));
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

            GUILayout.BeginHorizontal();
            GUILayout.Label("Poradnik", GUILayout.MaxWidth(75));
            baseScript.constelationPreset.guideImage = (Sprite)EditorGUILayout.ObjectField(baseScript.constelationPreset.guideImage, typeof(Sprite), true, GUILayout.MaxWidth(200));
            GUILayout.EndHorizontal();

            GUILayout.Space(30);
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
                temp.titleHeight = baseScript.constelationPreset.titleHeight;
                temp.guideImage = baseScript.constelationPreset.guideImage;
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.CreateAsset(temp, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                baseScript.constelationPreset = temp;
                EditorUtility.SetDirty(target);

            }
            GUILayout.Space(40);
        }
        if (GUI.changed)
        {
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

        for (int i = 0; i < baseScript.constelationPreset.size; i++)
        {
            if (gizmosMode != null && gizmosMode.Length == baseScript.constelationPreset.size)
                if (gizmosMode[i])
                {
                    Vector3 buffor = Handles.PositionHandle(baseScript.constelationPreset.nodes[i].position + baseScript.transform.position, Quaternion.identity);
                    baseScript.constelationPreset.nodes[i].position = buffor - baseScript.transform.position;
                    Repaint();
                }
        }
    }

    bool IsNodesExists(SOConstelationBase preset, int _id_1, int _id_2)
    {
        if (_id_1 >= preset.nodes.Length || _id_2 >= preset.nodes.Length || _id_1 < 0 || _id_2 < 0 || _id_1 == _id_2)
            return false;
        return true;
    }

    void MoveAllStars(Vector3 delta, ConstelationInSceneHelper baseScript)
    {
        for (int i = 0; i < baseScript.constelationPreset.size; i++)
        {
            baseScript.constelationPreset.nodes[i].position += delta;
        }
    }
}
