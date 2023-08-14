using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
[CustomEditor(typeof(AutoHingeConnector))]
public class AutoHingeConnectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AutoHingeConnector hingeConnector = (AutoHingeConnector)target;
        if(GUILayout.Button("Connect Children"))
        {
            hingeConnector.Connect();
        }
    }
}
