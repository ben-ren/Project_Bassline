using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenerateString))]
public class GenerateStringEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GenerateString generator = (GenerateString)target;
        if(GUILayout.Button("Generate String"))
        {
            generator.Generate();
        }
    }
}
