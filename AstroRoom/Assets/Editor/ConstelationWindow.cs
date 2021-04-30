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
    public List<GameObject> helpers;
    public List<Node> nodes;
    int tempNodesCount;
    bool displayMatrixToggle = false;
    [MenuItem("Window/Constelation")]
    public static void ShowWindow()
    {
        GetWindow<ConstelationWindow>("Composition");
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
                helpers = new List<GameObject>();
                nodes = new List<Node>();
            }
            Repaint();
        }

        if (nodesCount != 0)
        {
            if (GUILayout.Button("Display matrix"))
            {
                string row = "";
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
                Debug.Log(row);
            }

            /*            if (GUILayout.Button("Add node") && helpers.Count< adjMatrix.GetLength(0))
                        {
                            Node node = new Node(Vector3.zero, helpers.Count);
                            nodes.Add(node);
                            Repaint();
                        }*/

            if (GUILayout.Button("Restart"))
            {
                nodesCount = 0;
                foreach (GameObject helper in helpers)
                {
                    DestroyImmediate(helper);
                }
                helpers.Clear();
                nodes.Clear();
            }
            if (GUILayout.Button("Display adj matrix"))
            {
                displayMatrixToggle = !displayMatrixToggle;
            }



            if (displayMatrixToggle)
            {
                GUILayout.BeginHorizontal();
                GUIStyle style = new GUIStyle();
                style.fixedWidth = 20;
                style.normal.textColor = Color.white;
                style.alignment = TextAnchor.MiddleCenter;
                GUILayout.Label(" ", style);
                for (int i = 0; i < adjMatrix.GetLength(0); i++)
                {
                    GUILayout.Label(i.ToString());
                }
                GUILayout.EndHorizontal();
                for (int i = 0; i < adjMatrix.GetLength(0); i++)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(i.ToString(), style);
                    for (int j = 0; j < adjMatrix.GetLength(1); j++)
                    {
                        if (i == j)
                        {
                            GUILayout.Label("-");
                        }
                        else
                        {
                            adjMatrix[i, j] = EditorGUILayout.Toggle(adjMatrix[i, j]);
                        }

                    }
                    GUILayout.EndHorizontal();
                }
            }
        }
    }
}
