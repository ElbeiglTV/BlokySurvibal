using UnityEditor;
using UnityEngine;

public class InspectorReadOnly : PropertyAttribute
{
  
}

[CustomPropertyDrawer(typeof(InspectorReadOnly))]
public class InspectorReadOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false; // Deshabilita el control para hacerlo de solo lectura
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = true;  // Vuelve a habilitar los controles
    }
}