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

/*        if (baseScript.adjMatrix == null)
            return;*/

/*        for (int i = 0; i < baseScript.adjMatrix.GetLength(0); i++)
        {


            for (int j = 0; j < baseScript.adjMatrix.GetLength(0); j++)
            {
                if (baseScript.adjMatrix[i, j] == false)
                {
                    temp += "0 ";
                }
                else
                {
                    temp += "1 ";
                }
            }
            EditorGUILayout.LabelField(temp);
            temp = "";
        }*/
    }
}
