using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using UnityEngine.Rendering;
using Unity.VisualScripting;

[InitializeOnLoad]
public class ScriptHoverPreview : Editor
{
    static PreviewRenderUtility previewRenderUtility;
    static Mesh previewMesh; // Variable para almacenar el mesh de previsualización
    static Vector2 previewPosition; // Posición de la previsualización


    private void OnDisable()
    {
        Cleanup();
    }
    static ScriptHoverPreview()
    {
        previewRenderUtility = new PreviewRenderUtility();
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

                    DrawPreview();
                }
            }
        }
    }
    
    static void DrawPreview()
    {
        if (previewRenderUtility != null && previewMesh != null)
        {
            Bounds bounds = previewMesh.bounds;
            float boundingBoxSize = bounds.size.z;
            // Calcula la distancia de la cámara para que el mesh entre completamente en el campo de visión
            float cameraDistance = 20;

            // Ajusta el plano cercano de la cámara para evitar el recorte del mesh
            float desiredNearClipDistance = cameraDistance - boundingBoxSize;
            previewRenderUtility.camera.nearClipPlane = 0.3f; // Ajusta el valor mínimo según sea necesario
            previewRenderUtility.camera.farClipPlane = 1000;

            // Coloca la cámara en la posición adecuada
            previewRenderUtility.camera.transform.position = bounds.center - previewRenderUtility.camera.transform.forward * cameraDistance;

            Debug.Log(previewRenderUtility.camera.transform.position);
            // Mira hacia el centro del bounding box
            //previewRenderUtility.camera.transform.LookAt(bounds.center);



            // Establecer el fondo transparente / skybox

            previewRenderUtility.camera.clearFlags = CameraClearFlags.Nothing;

            // Preparar la previsualización
            previewRenderUtility.BeginPreview(new Rect(previewPosition.x, previewPosition.y, 300, 300), GUIStyle.none);
            previewRenderUtility.DrawMesh(previewMesh, Matrix4x4.identity, DefaultMaterial(), 0);
            previewRenderUtility.camera.Render();
            Texture previewTexture = previewRenderUtility.EndPreview();
            

            // Mostrar la previsualización
            GUI.DrawTexture(new Rect(previewPosition.x, previewPosition.y, 300, 300), previewTexture);
        }
        else if (previewRenderUtility != null)
        {
          previewRenderUtility.Cleanup();

        }
    }
    private static Material DefaultMaterial()
    {
        if (GraphicsSettings.renderPipelineAsset != null && GraphicsSettings.renderPipelineAsset.GetType().Name == "UniversalRenderPipelineAsset")
        {
            return new Material(Shader.Find("Universal Render Pipeline/Lit"));
        }
        else
        {
            return new Material(Shader.Find("Standard"));
        }
    }

    // Verifica si el tipo implementa la interfaz IMesh
    static bool HasIMeshInterface(Type type)
    {
        return type != null && type.GetInterfaces().Contains(typeof(IMesh));
    }
}
