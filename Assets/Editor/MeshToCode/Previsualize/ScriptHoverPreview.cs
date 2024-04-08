using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

[InitializeOnLoad]
public class ScriptHoverPreview
{
    static GUIStyle style;

    static ScriptHoverPreview()
    {
        // Registra el evento de la ventana del proyecto
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemOnGUI;
    }

    static void OnProjectWindowItemOnGUI(string guid, Rect selectionRect)
    {
        Event e = Event.current;
        if (e.type == EventType.Repaint && selectionRect.Contains(e.mousePosition))
        {
            // Obtiene la ruta del asset
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            // Obtiene el MonoScript asociado al asset
            MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(assetPath);
            // Verifica si el asset es un script C#
            if (script != null && HasIMeshInterface(script.GetClass()))
            {
                if (style == null)
                {
                    // Crea un estilo para el texto de previsualización
                    style = new GUIStyle();
                    style.normal.textColor = Color.green;
                    style.alignment = TextAnchor.MiddleCenter;
                }

                // Dibuja un texto de previsualización en la posición del mouse
                Handles.BeginGUI();
                GUI.Label(new Rect(e.mousePosition.x, e.mousePosition.y, 100, 20), "Previsualización", style);
                Handles.EndGUI();
            }
        }
    }

    // Verifica si el tipo implementa la interfaz IMesh
    static bool HasIMeshInterface(Type type)
    {
        return type != null && type.GetInterfaces().Contains(typeof(IMesh));
    }
}
