using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Variables para el MeshFilter y MeshRenderer
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Crear un nuevo GameObject y agregar MeshFilter y MeshRenderer
        GameObject cubeObject = new GameObject("Cube");
        meshFilter = cubeObject.AddComponent<MeshFilter>();
        meshRenderer = cubeObject.AddComponent<MeshRenderer>();

        // Generar el cubo y asignar el Mesh al MeshFilter
        Mesh cubeMesh = GenerateCubeMesh();
        meshFilter.mesh = cubeMesh;

        // Asignar un material al MeshRenderer (puedes cambiar esto según tus necesidades)
        meshRenderer.material = new Material(Shader.Find("Standard"));
    }

    // Función para generar el Mesh de un cubo
    private Mesh GenerateCubeMesh()
    {
        Mesh mesh = new Mesh();

        // Definir los vértices del cubo
        Vector3[] vertices = {
            new Vector3(-0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, 0.5f, -0.5f),
            new Vector3(0.5f, -0.5f, -0.5f),
            new Vector3(-0.5f, -0.5f, 0.5f),
            new Vector3(-0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, 0.5f, 0.5f),
            new Vector3(0.5f, -0.5f, 0.5f)
        };

        // Definir los triángulos que componen las caras del cubo
        int[] triangles = {
            0, 1, 2, // Front
            0, 2, 3,
            1, 5, 6, // Top
            1, 6, 2,
            4, 0, 3, // Bottom
            4, 3, 7,
            4, 5, 1, // Left
            4, 1, 0,
            3, 2, 6, // Right
            3, 6, 7,
            5, 4, 7, // Back
            5, 7, 6
        };

        // Asignar los vértices y los triángulos al Mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // Recalcular la información del Mesh
        mesh.RecalculateNormals();

        return mesh;
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar aquí la lógica para controlar la visibilidad de las caras del cubo si lo deseas
    }
}
