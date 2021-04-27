using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ConstelationController))]
public class ConstelationEditor : Editor
{
    private Editor _editor;

    private string editorMode = "Change to EDGE mode";
    public bool edgeMode = false;
    ConstelationController baseScript;

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



        if (GUILayout.Button(editorMode))
        {
            edgeMode = !edgeMode;
            if (edgeMode)
            {
                editorMode = "Change to NODE mode";
            }

            if (edgeMode==false)
            {
                editorMode = "Change to EDGE mode";
            }
        }

    }

    public void OnSceneGUI()
    {
        baseScript = target as ConstelationController;
        if (baseScript == null || baseScript.constelationPreset == null)
            return;

        GUIStyle nodeTextStyle = new GUIStyle();
        Handles.color = Color.red;
        nodeTextStyle.fontSize = 20;
        int nodeIndex = 0;



        if (edgeMode)
        {

        }
        else
        {
            foreach (var node in baseScript.constelationPreset.nodes)
            {

                /*            node.position = Handles.PositionHandle(node.position, Quaternion.identity);*/


                node.position = (Vector2)Handles.FreeMoveHandle(node.position, Quaternion.identity, .125f, Vector3.zero, Handles.SphereHandleCap);


                Handles.Label(node.position, nodeIndex.ToString(), nodeTextStyle);

                nodeIndex++;
                Repaint();
            }

        }
        SceneView.RepaintAll();

    }

    /*void Input(ConstelationController baseScript)
    {
        Event guiEvent = Event.current;

        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
        {
            baseScript.constelationPreset.AddNode(baseScript.transform.position + new Vector3(0, 1));
        }

        *//*        Ray ray = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Handles.
                }*//*
        if (Event.current.type == EventType.MouseDown && guiEvent.button == 0)
        {
            int controlID = GUIUtility.GetControlID(FocusType.Passive);
            Debug.Log(HandleUtility.nearestControl +"    "+controlID+"         "+ GUIUtility.hotControl);
            
            
        }
    }*/
}
