using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SOConstelationBase))]
public class SOConstelationBaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
    }
}
