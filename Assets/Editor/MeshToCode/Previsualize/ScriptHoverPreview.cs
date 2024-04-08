using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

[InitializeOnLoad]
public class ScriptHoverPreview
{
    static Mesh previewMesh; // Variable para almacenar el mesh de previsualización
    static Vector2 previewPosition; // Posición de la previsualización

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
            // Verifica si el asset es un script C# y si implementa la interfaz IMesh
            if (script != null && HasIMeshInterface(script.GetClass()))
            {
                // Obtiene la clase del script
                Type scriptClass = script.GetClass();
                // Crea una instancia del script
                IMesh meshGenerator = (IMesh)Activator.CreateInstance(scriptClass);
                // Genera el mesh
                previewMesh = meshGenerator.Previsualize();

                if (previewMesh != null)
                {
                    // Calcular la posición de la previsualización cerca del cursor del mouse
                    previewPosition = new Vector2(e.mousePosition.x + 10, e.mousePosition.y + 10); // Ajusta según sea necesario

                    // Dibuja el mesh de previsualización en la posición calculada
                    Handles.BeginGUI();
                    Handles.color = Color.green;
                    Handles.DrawWireCube(new Rect(previewPosition.x, previewPosition.y, 100, 100).center, Vector3.one);
                    Handles.EndGUI();
                }
            }
        }
    }

    // Verifica si el tipo implementa la interfaz IMesh
    static bool HasIMeshInterface(Type type)
    {
        return type != null && type.GetInterfaces().Contains(typeof(IMesh));
    }
}
