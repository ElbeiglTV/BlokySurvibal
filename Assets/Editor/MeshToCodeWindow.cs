using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

public class MeshToCodeWindow : EditorWindow
{
    private Mesh meshToConvert;

    [MenuItem("Tools/Mesh To Code")]
    public static void ShowWindow()
    {
        GetWindow<MeshToCodeWindow>("Mesh To Code");
    }

    private void OnGUI()
    {
        GUILayout.Label("Convert Mesh To Code", EditorStyles.boldLabel);

        meshToConvert = EditorGUILayout.ObjectField("Mesh to Convert", meshToConvert, typeof(Mesh), true) as Mesh;

        if (GUILayout.Button("Generate Code"))
        {
            if (meshToConvert != null)
            {
                string generatedCode = ConvertMeshToCode(meshToConvert);
                SaveCodeToFile(generatedCode, meshToConvert.name);
            }
            else
            {
                Debug.LogError("Mesh not provided!");
            }
        }
    }

    private string ConvertMeshToCode(Mesh mesh)
    {
        StringBuilder codeBuilder = new StringBuilder();

        codeBuilder.AppendLine("using UnityEngine;");
        codeBuilder.AppendLine("[ExecuteInEditMode]");
        codeBuilder.AppendLine($"public class {mesh.name} : MonoBehaviour"); // Cambia el nombre de la clase aquí
        codeBuilder.AppendLine("{");
        codeBuilder.AppendLine("    void Start()");
        codeBuilder.AppendLine("    {");
        codeBuilder.AppendLine("        GameObject obj = gameObject;");
        codeBuilder.AppendLine("        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();");
        codeBuilder.AppendLine("        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();");

        codeBuilder.AppendLine("        meshFilter.sharedMesh = new Mesh();");

        Vector3[] vertices = mesh.vertices;
        codeBuilder.AppendLine("        meshFilter.mesh.vertices = new Vector3[] {");
        for (int i = 0; i < vertices.Length; i++)
        {
            codeBuilder.AppendLine($"            new Vector3({vertices[i].x.ToString(CultureInfo.InvariantCulture)}f, {vertices[i].y.ToString(CultureInfo.InvariantCulture)}f, {vertices[i].z.ToString(CultureInfo.InvariantCulture)}f),");
        }
        codeBuilder.AppendLine("        };");

        int[] triangles = mesh.triangles;
        codeBuilder.AppendLine("        meshFilter.mesh.triangles = new int[] {");
        for (int i = 0; i < triangles.Length; i += 3)
        {
            codeBuilder.AppendLine($"            {triangles[i]}, {triangles[i + 1]}, {triangles[i + 2]},");
        }
        codeBuilder.AppendLine("        };");

        Vector3[] normals = mesh.normals;
        codeBuilder.AppendLine("        meshFilter.mesh.normals = new Vector3[] {");
        for (int i = 0; i < normals.Length; i++)
        {
            codeBuilder.AppendLine($"            new Vector3({normals[i].x.ToString(CultureInfo.InvariantCulture)}f, {normals[i].y.ToString(CultureInfo.InvariantCulture)}f, {normals[i].z.ToString(CultureInfo.InvariantCulture)}f),");
        }
        codeBuilder.AppendLine("        };");

        Vector2[] uvs = mesh.uv;
        codeBuilder.AppendLine("        meshFilter.mesh.uv = new Vector2[] {");
        for (int i = 0; i < uvs.Length; i++)
        {
            codeBuilder.AppendLine($"            new Vector2({uvs[i].x.ToString(CultureInfo.InvariantCulture)}f, {uvs[i].y.ToString(CultureInfo.InvariantCulture)}f),");
        }
        codeBuilder.AppendLine("        };");
        codeBuilder.AppendLine("DestroyImmediate(this);");

        codeBuilder.AppendLine("    }");
        codeBuilder.AppendLine("}");

        return codeBuilder.ToString();
    }

    private void SaveCodeToFile(string code, string fileName)
    {
        string filePath = EditorUtility.SaveFilePanel("Save Mesh Code", "", fileName + ".cs", "cs");
        if (!string.IsNullOrEmpty(filePath))
        {
            File.WriteAllText(filePath, code);
            Debug.Log("Mesh code generated and saved to: " + filePath);
        }
    }
}
