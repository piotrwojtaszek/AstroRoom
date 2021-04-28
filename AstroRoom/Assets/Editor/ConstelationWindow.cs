using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;
public class ConstelationWindow : EditorWindow
{
    public SOConstelationBase constelationPreset;

    public GameObject selected;

    [MenuItem("Window/Constelation")]
    public static void ShowWindow()
    {
        GetWindow<ConstelationWindow>("Composition");
    }

    private void OnGUI()
    {
        GUILayout.Label("Constelation Preset", EditorStyles.boldLabel);

        constelationPreset = EditorGUILayout.ObjectField(constelationPreset, typeof(SOConstelationBase), true) as SOConstelationBase;
        selected = EditorGUILayout.ObjectField(selected, typeof(GameObject), true) as GameObject;

        if (GUILayout.Button("Add node"))
        {
            constelationPreset.AddNode(Vector3.zero);
        }

        selected = Selection.activeGameObject;
    }

    private void OnSelectionChange()
    {

    }

    private void Update()
    {
        if (Keyboard.current.aKey.isPressed && selected != null)
            constelationPreset.RemoveNode(selected);
        Repaint();
    }
}
