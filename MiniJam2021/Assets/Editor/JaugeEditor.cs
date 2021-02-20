using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Jauge))]
public class JaugeEditor : Editor
{
    Jauge jauge;
    public override void OnInspectorGUI()
    {
        jauge = target as Jauge;

        GUILayout.Label("coucou");
        GUILayout.Space(20);
        base.OnInspectorGUI();

        if (GUILayout.Button("générer mappe"))
        {

        }
        if (GUILayout.Button("yo"))
        {

        }
    }
}
