using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
using System.Linq;
public class ConstelationWindow : EditorWindow
{
    public int nodesCount;
    public bool[,] adjMatrix;
    public GameObject inSceneHelper;
    public List<Node> nodes;
    int tempNodesCount;
    bool displayMatrixToggle = false;

    [MenuItem("Window/Constelation")]
    public static void ShowWindow()
    {
        EditorWindow editorWindow = GetWindow<ConstelationWindow>("Composition");
        editorWindow.autoRepaintOnSceneChange = true;
        editorWindow.Show();
    }

    private void Awake()
    {
        /* GameObject[] find = GameObject.FindObjectsOfType(typeof())*/
    }
    private void OnGUI()
    {

        /*constelationPreset = EditorGUILayout.ObjectField(constelationPreset, typeof(SOConstelationBase), true) as SOConstelationBase;*/
        if (nodesCount == 0)
        {
            GUILayout.Label("How many nodes?");

            tempNodesCount = EditorGUILayout.IntField(tempNodesCount);
            if (GUILayout.Button("Confirm"))
            {

                nodesCount = tempNodesCount;
                adjMatrix = new bool[nodesCount, nodesCount];
                nodes = new List<Node>();
            }
            Repaint();
        }

        if (nodesCount != 0)
        {
            if (GUILayout.Button("Display nodes"))
            {
                /*                string row = "";
                                for (int i = 0; i < adjMatrix.GetLength(0); i++)
                                {

                                    for (int j = 0; j < adjMatrix.GetLength(1); j++)
                                    {
                                        if (adjMatrix[i, j] == false)
                                            row += "0";
                                        if (adjMatrix[i, j] == true)
                                            row += "1";
                                        row += " ";
                                    }
                                    row += '\n';
                                }
                                Debug.Log(row);*/
                inSceneHelper = new GameObject("Constelation Helper");
                inSceneHelper.AddComponent<ConstelationInSceneHelper>();
                
            }

            if (GUILayout.Button("Restart"))
            {
                nodesCount = 0;
                DestroyImmediate(inSceneHelper);
                nodes.Clear();
            }

            if (GUILayout.Button("Display matrix"))
            {
                displayMatrixToggle = !displayMatrixToggle;
            }

            if (displayMatrixToggle)
            {
                GUILayout.BeginHorizontal();
                GUIStyle style = new GUIStyle();
                style.alignment = TextAnchor.MiddleCenter;

                GUILayout.Label(" ", GUILayout.Width(30));
                for (int i = 0; i < adjMatrix.GetLength(0); i++)
                {
                    GUILayout.Label(i.ToString(), GUILayout.Width(29));
                }
                GUILayout.EndHorizontal();
                for (int i = 0; i < adjMatrix.GetLength(0); i++)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(i.ToString(), GUILayout.Width(30));
                    for (int j = 0; j < adjMatrix.GetLength(1); j++)
                    {
                        if (i == j)
                        {
                            GUIStyle label = new GUIStyle();
                            label.fixedWidth = 30;
                            GUILayout.Label("", label);
                        }
                        else
                        {
                            adjMatrix[i, j] = EditorGUILayout.Toggle(adjMatrix[i, j], GUILayout.Width(30));
                        }

                    }
                    GUILayout.EndHorizontal();
                }
            }
        }
    }
}
