using UnityEditor;
using UnityEngine;

public class PreviewMesh : EditorWindow
{
    private PreviewRenderUtility m_PreviewRenderUtility;

    private float rotateMesh;


    private void OnDisable()
    {
        if (m_PreviewRenderUtility != null)
        {
            m_PreviewRenderUtility.Cleanup();
            m_PreviewRenderUtility = null;
        }
    }
    [MenuItem("Window/MeshViewer")]
    public static void ShowWindow()
    {
        var window = GetWindow<PreviewMesh>("Mesh Viewer");
        window.autoRepaintOnSceneChange = true;
        window.Show();
        var window2 = GetWindow<ViewerConfig>("Mesh Viewer Configs");
        window2.autoRepaintOnSceneChange = true;
        window2.Show();



    }
    private void OnGUI()
    {
        if (m_PreviewRenderUtility == null) m_PreviewRenderUtility = new PreviewRenderUtility();


        m_PreviewRenderUtility.camera.nearClipPlane = 0.3f;
        m_PreviewRenderUtility.camera.farClipPlane = 1000;



        m_PreviewRenderUtility.camera.orthographic = true;





        m_PreviewRenderUtility.camera.clearFlags = CameraClearFlags.Skybox;

        // Preparar la previsualización
        m_PreviewRenderUtility.BeginStaticPreview(new Rect(0, 0, position.width, position.height));
        if (Selection.activeGameObject != null)
        {

            MeshFilter filter = Selection.activeGameObject.GetComponent<MeshFilter>();
            MeshRenderer renderer = Selection.activeGameObject.GetComponent<MeshRenderer>();

            if (StaticViewerConfigs.PreviewMaterial == null)
            {

                StaticViewerConfigs.PreviewMaterial = renderer.material;
            }

            if (filter != null && renderer != null)
            {
                Bounds bounds = filter.sharedMesh.bounds;

                float cameraDistance = bounds.size.magnitude * 2;
                m_PreviewRenderUtility.camera.orthographicSize = bounds.size.magnitude;

                m_PreviewRenderUtility.camera.transform.position = -(m_PreviewRenderUtility.camera.transform.forward * cameraDistance + new Vector3(0, -StaticViewerConfigs.Haigt, bounds.size.z));
                m_PreviewRenderUtility.camera.transform.LookAt(bounds.center);

                rotateMesh += StaticViewerConfigs.RotateSpeed * Time.deltaTime;
                m_PreviewRenderUtility.DrawMesh(filter.sharedMesh, bounds.center, Quaternion.Euler(0, rotateMesh, 0), StaticViewerConfigs.PreviewMaterial, 0);
                Repaint();

            }
        }

        m_PreviewRenderUtility.camera.Render();
        Texture previewTexture = m_PreviewRenderUtility.EndStaticPreview();


        // Mostrar la previsualización
        GUI.DrawTexture(new Rect(0, 0, position.width, position.height), previewTexture);
    }
}

