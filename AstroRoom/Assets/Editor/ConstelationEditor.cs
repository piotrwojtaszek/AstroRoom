using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ConstelationController))]
public class ConstelationEditor : Editor
{

    private Editor _editor;
    public SOConstelationBase ConstelationBase;


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.Space();
        serializedObject.Update();

        var myAsset = serializedObject.FindProperty("constelationPreset");
        if (myAsset.objectReferenceValue == null)
            return;
        CreateCachedEditor(myAsset.objectReferenceValue, null, ref _editor);
        _editor.OnInspectorGUI();

        serializedObject.ApplyModifiedProperties();
    }

    public void OnSceneGUI()
    {
        ConstelationController baseScript = target as ConstelationController;
        if (baseScript == null)
            return;

        Input(baseScript);

        GUIStyle nodeTextStyle = new GUIStyle();
        Handles.color = Color.red;
        nodeTextStyle.fontSize = 20;
        int nodeIndex = 0;

        foreach (var node in baseScript.constelationPreset.nodes)
        {
            node.position = (Vector2)Handles.FreeMoveHandle(node.position, Quaternion.identity, .125f, Vector3.zero, Handles.SphereHandleCap);
            Handles.Label(node.position, nodeIndex.ToString(), nodeTextStyle);

            nodeIndex++;
            Repaint();
        }
    }

    void Input(ConstelationController baseScript)
    {
        Event guiEvent = Event.current;

        Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

        if(guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
        {
            baseScript.constelationPreset.AddNode(mousePos);
        }
    }
}
