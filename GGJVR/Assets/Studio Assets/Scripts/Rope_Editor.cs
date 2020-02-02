using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Rope_Generator))]
public class Rope_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Rope_Generator ropeTarget = (Rope_Generator)target;

        if (GUILayout.Button("Generate Rope"))
        {
            ropeTarget.GenerateRope();
        }

        if (GUILayout.Button("Clear Rope"))
        {
            ropeTarget.ClearRope();
        }
    }
}
