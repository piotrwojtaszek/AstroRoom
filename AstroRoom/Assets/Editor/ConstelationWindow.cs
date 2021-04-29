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

    [MenuItem("Window/Constelation")]
    public static void ShowWindow()
    {
        GetWindow<ConstelationWindow>("Composition");

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

        if (GUILayout.Button("Add node"))
        {
            constelationPreset.AddNode(Vector3.zero, debugNodePrefab);
        }

        if (Selection.activeGameObject != null)
            if (Selection.activeGameObject.CompareTag("DebugNode"))
                if (GUILayout.Button("Delete node"))
                {
                    constelationPreset.RemoveNode(Selection.activeGameObject);
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
            constelationPreset.AddEdge(selected[0].GetComponent<ConstelationSocket>().node, selected[1].GetComponent<ConstelationSocket>().node, debugEdgePrefab);
        }

        Repaint();
    }
}
