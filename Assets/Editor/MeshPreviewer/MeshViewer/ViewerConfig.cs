using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ViewerConfig : EditorWindow
{
    private MaterialEditor materialEditor;


    private void OnGUI()
    {
        
        GUILayout.BeginVertical();
        StaticViewerConfigs.Height = EditorGUILayout.FloatField("Height",StaticViewerConfigs.Height);
        StaticViewerConfigs.RotateSpeed = EditorGUI.Slider(new Rect(0, 20, position.width, 20),"Rotate Speed", StaticViewerConfigs.RotateSpeed, 0, 100);
        GUILayout.Space(20);
        StaticViewerConfigs.PreviewMaterial = (Material)EditorGUILayout.ObjectField("PreviewMaterial", StaticViewerConfigs.PreviewMaterial, typeof (Material), false);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        MostrarMaterial();
        GUILayout.EndVertical();


    }
    private void MostrarMaterial()
    {
        if (StaticViewerConfigs.PreviewMaterial != null)
        {
            
                materialEditor = (MaterialEditor)Editor.CreateEditor(StaticViewerConfigs.PreviewMaterial);

            materialEditor.DrawHeader();
            materialEditor.OnInspectorGUI();
        }
    }
}
