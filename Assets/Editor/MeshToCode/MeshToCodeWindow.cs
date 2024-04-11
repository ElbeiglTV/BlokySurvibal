using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

public class MeshToCodeWindow : Editor
{
    private Mesh meshToConvert;

    [MenuItem("Assets/Convert/Mesh To Code", true)]
    private static bool ValidateMeshToCode()
    {
        // Obtener la ruta del asset seleccionado
        string selectedAssetPath = AssetDatabase.GetAssetPath(Selection.activeObject);

        // Habilitar el ítem del menú solo si el asset seleccionado es un Mesh
        return !string.IsNullOrEmpty(selectedAssetPath) && AssetDatabase.LoadAssetAtPath<Mesh>(selectedAssetPath) != null;
    }
    [MenuItem("Assets/Convert/Mesh To Code")]
    private static void MeshToCode()
    {
        // Obtener la ruta del asset seleccionado
        string selectedAssetPath = AssetDatabase.GetAssetPath(Selection.activeObject);

        // Cargar el mesh desde el asset seleccionado
        Mesh mesh = AssetDatabase.LoadAssetAtPath<Mesh>(selectedAssetPath);

        // Ejecutar la función de procesamiento
        SaveCodeToFile(ConvertMeshToCode(mesh, Selection.activeObject.name), selectedAssetPath);

        MonoScript generatedScript = AssetDatabase.LoadAssetAtPath<MonoScript>(selectedAssetPath.Replace(".fbx", ".cs"));

        // Cargar el icono personalizado
        Texture2D customIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Editor/Icons/CustomIcon.png"); // Ajusta la ruta según donde tengas guardado tu icono

        // Asignar el icono al MonoScript
        EditorGUIUtility.SetIconForObject(generatedScript, customIcon);



    }



    private static string ConvertMeshToCode(Mesh mesh,string FileName)
    {
        StringBuilder codeBuilder = new StringBuilder();

        codeBuilder.AppendLine("using UnityEngine;");
        codeBuilder.AppendLine("using UnityEngine.Rendering;");
        codeBuilder.AppendLine("[ExecuteInEditMode]");
        codeBuilder.AppendLine($"public class {FileName} : MonoBehaviour"); // Cambia el nombre de la clase aquí
        codeBuilder.AppendLine("{");
        codeBuilder.AppendLine("    void Start()");
        codeBuilder.AppendLine("    {");
        codeBuilder.AppendLine("        GameObject obj = gameObject;");
        codeBuilder.AppendLine("        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();");
        codeBuilder.AppendLine("        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();");

        codeBuilder.AppendLine("        meshFilter.sharedMesh = new Mesh();");

        Vector3[] vertices = mesh.vertices;
        codeBuilder.AppendLine("        meshFilter.sharedMesh.vertices = new Vector3[] {");
        for (int i = 0; i < vertices.Length; i++)
        {
            codeBuilder.AppendLine($"            new Vector3({vertices[i].x.ToString(CultureInfo.InvariantCulture)}f, {vertices[i].y.ToString(CultureInfo.InvariantCulture)}f, {vertices[i].z.ToString(CultureInfo.InvariantCulture)}f),");
        }
        codeBuilder.AppendLine("        };");

        int[] triangles = mesh.triangles;
        codeBuilder.AppendLine("        meshFilter.sharedMesh.triangles = new int[] {");
        for (int i = 0; i < triangles.Length; i += 3)
        {
            codeBuilder.AppendLine($"            {triangles[i]}, {triangles[i + 1]}, {triangles[i + 2]},");
        }
        codeBuilder.AppendLine("        };");

        Vector3[] normals = mesh.normals;
        codeBuilder.AppendLine("        meshFilter.sharedMesh.normals = new Vector3[] {");
        for (int i = 0; i < normals.Length; i++)
        {
            codeBuilder.AppendLine($"            new Vector3({normals[i].x.ToString(CultureInfo.InvariantCulture)}f, {normals[i].y.ToString(CultureInfo.InvariantCulture)}f, {normals[i].z.ToString(CultureInfo.InvariantCulture)}f),");
        }
        codeBuilder.AppendLine("        };");

        Vector2[] uvs = mesh.uv;
        codeBuilder.AppendLine("        meshFilter.sharedMesh.uv = new Vector2[] {");
        for (int i = 0; i < uvs.Length; i++)
        {
            codeBuilder.AppendLine($"            new Vector2({uvs[i].x.ToString(CultureInfo.InvariantCulture)}f, {uvs[i].y.ToString(CultureInfo.InvariantCulture)}f),");
        }
        codeBuilder.AppendLine("        };");
        codeBuilder.AppendLine("        meshRenderer.material = GetDefaultMaterial();");

        codeBuilder.AppendLine("        DestroyImmediate(this);");

        codeBuilder.AppendLine("    }");
        codeBuilder.AppendLine("    private Material GetDefaultMaterial()");
        codeBuilder.AppendLine("    {");
        codeBuilder.AppendLine("        if(GraphicsSettings.renderPipelineAsset != null && GraphicsSettings.renderPipelineAsset.GetType().Name == \"UniversalRenderPipelineAsset\")");
        codeBuilder.AppendLine("        {");
        codeBuilder.AppendLine("            return new Material(Shader.Find(\"Universal Render Pipeline/Lit\"));");
        codeBuilder.AppendLine("        }");
        codeBuilder.AppendLine("        else");
        codeBuilder.AppendLine("        {");
        codeBuilder.AppendLine("            return new Material(Shader.Find(\"Standard\"));");
        codeBuilder.AppendLine("        }");
        codeBuilder.AppendLine("    }");
        codeBuilder.AppendLine("}");

        
        codeBuilder.AppendLine($"public class {FileName+"Preview"} : IMesh");
        codeBuilder.AppendLine("{");

        codeBuilder.AppendLine("    public Mesh Previsualize()");
        codeBuilder.AppendLine("    {");
        codeBuilder.AppendLine("       Mesh mesh = new Mesh();");
        codeBuilder.AppendLine("       mesh.vertices = new Vector3[] {");
        for (int i = 0; i < vertices.Length; i++)
        {
            codeBuilder.AppendLine($"            new Vector3({vertices[i].x.ToString(CultureInfo.InvariantCulture)}f, {vertices[i].y.ToString(CultureInfo.InvariantCulture)}f, {vertices[i].z.ToString(CultureInfo.InvariantCulture)}f),");
        }
        codeBuilder.AppendLine("        };");

        codeBuilder.AppendLine("        mesh.triangles = new int[] {");
        for (int i = 0; i < triangles.Length; i += 3)
        {
            codeBuilder.AppendLine($"            {triangles[i]}, {triangles[i + 1]}, {triangles[i + 2]},");
        }
        codeBuilder.AppendLine("        };");

        codeBuilder.AppendLine("        mesh.normals = new Vector3[] {");
        for (int i = 0; i < normals.Length; i++)
        {
            codeBuilder.AppendLine($"            new Vector3({normals[i].x.ToString(CultureInfo.InvariantCulture)}f, {normals[i].y.ToString(CultureInfo.InvariantCulture)}f, {normals[i].z.ToString(CultureInfo.InvariantCulture)}f),");
        }
        codeBuilder.AppendLine("        };");

        codeBuilder.AppendLine("        mesh.uv = new Vector2[] {");
        for (int i = 0; i < uvs.Length; i++)
        {
            codeBuilder.AppendLine($"            new Vector2({uvs[i].x.ToString(CultureInfo.InvariantCulture)}f, {uvs[i].y.ToString(CultureInfo.InvariantCulture)}f),");
        }
        codeBuilder.AppendLine("        };");
        codeBuilder.AppendLine("        return mesh;");


        codeBuilder.AppendLine("    }");

        codeBuilder.AppendLine("}");

        return codeBuilder.ToString();
    }

    private static void SaveCodeToFile(string code,string Path)
    {
        
        if (!string.IsNullOrEmpty(Path))
        {
            Path = Path.Replace(".fbx", ".Cs");
            File.WriteAllText(Path, code);
            AssetDatabase.Refresh();
            Debug.Log("Mesh code generated and saved to: " + Path);
        }
    }
}
