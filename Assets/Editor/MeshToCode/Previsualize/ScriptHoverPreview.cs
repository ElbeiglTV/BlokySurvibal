using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

[InitializeOnLoad]
public class ScriptHoverPreview : Editor
{

    static PreviewRenderUtility previewRenderUtility;
    static Mesh previewMesh; // Variable para almacenar el mesh de previsualizaci�n
    static Vector2 previewPosition; // Posici�n de la previsualizaci�n
    static float rotateMesh;
   


    private void OnValidate()
    {
        previewRenderUtility.Cleanup();
    }

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
            // Obtiene la clase del script
            
            if (script != null)
            {
                

                string className = script.GetClass().ToString();

                Type[] tipos = script.GetClass().Assembly.GetTypes();

                

                Type PreviewClass = null;

                foreach (Type t in tipos) 
                {

                   
                    if (t.ToString().Contains(className)&&HasIMeshInterface(t))
                    {
                        PreviewClass = t;
                    }
                
                }


               

                // Crea una instancia del script
                if (PreviewClass != null)
                {

                    IMesh meshGenerator = (IMesh)Activator.CreateInstance(PreviewClass);
                    // Genera el mesh
                    previewMesh = meshGenerator.Previsualize();

                    if (previewMesh != null)
                    {
                        // Calcular la posici�n de la previsualizaci�n cerca del cursor del mouse
                        previewPosition = new Vector2(e.mousePosition.x + 10, e.mousePosition.y + 10); // Ajusta seg�n sea necesario

                        DrawPreview();
                        
                    }
                }

            }
        }
        else previewMesh = null;
    }

    static void DrawPreview()
    {
        if (previewRenderUtility != null && previewMesh != null)
        {
            Bounds bounds = previewMesh.bounds;

            // Calcula la distancia de la c�mara para que el mesh entre completamente en el campo de visi�n
            float cameraDistance = bounds.size.magnitude * 2;

            // Ajusta el plano cercano de la c�mara para evitar el recorte del mesh

            previewRenderUtility.camera.nearClipPlane = 0.3f; // Ajusta el valor m�nimo seg�n sea necesario
            previewRenderUtility.camera.farClipPlane = 1000;

            // Coloca la c�mara en la posici�n adecuada
            previewRenderUtility.camera.transform.position = -(previewRenderUtility.camera.transform.forward * cameraDistance + new Vector3(0, 0, bounds.size.z));

            previewRenderUtility.camera.orthographic = true;
            previewRenderUtility.camera.orthographicSize = bounds.size.magnitude;


            
            // Mira hacia el centro del bounding box
            //previewRenderUtility.camera.transform.LookAt(bounds.center);



            // Establecer el fondo transparente / skybox

            previewRenderUtility.camera.clearFlags = CameraClearFlags.Nothing;

            // Preparar la previsualizaci�n
            previewRenderUtility.BeginPreview(new Rect(previewPosition.x, previewPosition.y, 300, 300), GUIStyle.none);

            rotateMesh += 1;
            previewRenderUtility.DrawMesh(previewMesh,new Vector3(0,0,0),Quaternion.Euler(0,rotateMesh,0), DefaultMaterial(), 0);
            previewRenderUtility.camera.Render();
            Texture previewTexture = previewRenderUtility.EndPreview();


            // Mostrar la previsualizaci�n
            GUI.DrawTexture(new Rect(previewPosition.x, previewPosition.y, 300, 300), previewTexture);
            EditorApplication.RepaintProjectWindow();
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
