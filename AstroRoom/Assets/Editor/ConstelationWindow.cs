using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
public class ConstelationWindow : EditorWindow
{
    public SOConstelationBase constelationPreset;
    public GameObject debugNodePrefab;
    public GameObject debugEdgePrefab;

    public List<Node> _nodes = new List<Node>();
    public List<Edge> _edges = new List<Edge>();
    [MenuItem("Window/Constelation")]
    public static void ShowWindow()
    {
        GetWindow<ConstelationWindow>("Composition");
    }

    private void Awake()
    {

    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Constelation Preset", EditorStyles.boldLabel);
        constelationPreset = EditorGUILayout.ObjectField(constelationPreset, typeof(SOConstelationBase), true) as SOConstelationBase;
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Node Prefab");
        debugNodePrefab = EditorGUILayout.ObjectField(debugNodePrefab, typeof(GameObject), true) as GameObject;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Edge Prefab");
        debugEdgePrefab = EditorGUILayout.ObjectField(debugEdgePrefab, typeof(GameObject), true) as GameObject;
        GUILayout.EndHorizontal();
        GUILayout.Space(10);


        if (GUILayout.Button("Save"))
        {
            Save();
        }

        /*if (GUILayout.Button("Add node"))
        {
            constelationPreset.AddNode(debugNodePrefab);
        }

        if (Selection.activeGameObject != null)
            if (Selection.activeGameObject.CompareTag("DebugNode"))
                if (GUILayout.Button("Delete node"))
                {
                    constelationPreset.RemoveNode(Selection.activeGameObject);
                }

        if (Selection.activeGameObject != null)
            if (Selection.activeGameObject.CompareTag("DebugEdge"))
                if (GUILayout.Button("Delete connection"))
                {
                    constelationPreset.RemoveEdge(Selection.activeGameObject.GetComponent<ConstelationEdgeDebug>().edge);
                }*/

        if (GUILayout.Button("Add node"))
        {
            AddNode();
        }

        this.Repaint();
    }

    private void OnInspectorUpdate()
    {
        Repaint();
    }

    private void Update()
    {
        GameObject[] selected = Selection.gameObjects;

        if (Keyboard.current.jKey.isPressed && Keyboard.current.leftCtrlKey.isPressed && selected.Length == 2)
        {
            AddEdge(selected[0], selected[1]);
        }

        Repaint();
    }

    private void AddNode()
    {
        if (GameObject.Find("CONSTELATION") == null)
            new GameObject("CONSTELATION");

        GameObject temp = Instantiate(debugNodePrefab, GameObject.Find("CONSTELATION").transform);
    }


    private void AddEdge(GameObject selected_1, GameObject selected_2)
    {
        if (GameObject.Find("CONSTELATION") == null)
            new GameObject("CONSTELATION");

        GameObject temp = Instantiate(debugEdgePrefab, GameObject.Find("CONSTELATION").transform);
    }

    private void Save()
    {
        constelationPreset.nodes.Clear();
        foreach (Transform helper in GameObject.Find("CONSTELATION").transform)
        {
            if (helper.CompareTag("DebugNode"))
                constelationPreset.nodes.Add(new Node(helper.position));
        }
        constelationPreset.edges = _edges;
    }
}
