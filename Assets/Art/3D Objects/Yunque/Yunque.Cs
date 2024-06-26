using UnityEngine;
using UnityEngine.Rendering;
[ExecuteInEditMode]
public class Yunque : MonoBehaviour
{
    void Start()
    {
        GameObject obj = gameObject;
        MeshFilter meshFilter = obj.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = obj.AddComponent<MeshRenderer>();
        meshFilter.sharedMesh = new Mesh();
        meshFilter.sharedMesh.vertices = new Vector3[] {
            new Vector3(49.65339f, 50f, 0f),
            new Vector3(18.12582f, 50f, -22.61215f),
            new Vector3(18.12582f, 50f, 22.61215f),
            new Vector3(-50f, 50f, 22.61215f),
            new Vector3(-50f, 50f, -22.61215f),
            new Vector3(49.65339f, 50f, 0f),
            new Vector3(18.12582f, 50f, 22.61215f),
            new Vector3(18.12582f, 18f, 22.61218f),
            new Vector3(49.65339f, 18f, 0f),
            new Vector3(18.12582f, 50f, -22.61215f),
            new Vector3(49.65339f, 50f, 0f),
            new Vector3(49.65339f, 18f, 0f),
            new Vector3(18.12582f, 18f, -22.61218f),
            new Vector3(18.12582f, 50f, -22.61215f),
            new Vector3(18.12582f, 18f, -22.61218f),
            new Vector3(-50f, 18f, -22.61218f),
            new Vector3(-50f, 50f, -22.61215f),
            new Vector3(-50f, 50f, 22.61215f),
            new Vector3(-50f, 50f, -22.61215f),
            new Vector3(-50f, 18f, -22.61218f),
            new Vector3(-50f, 18f, 22.61218f),
            new Vector3(18.12582f, 18f, 22.61218f),
            new Vector3(18.12582f, 50f, 22.61215f),
            new Vector3(-50f, 50f, 22.61215f),
            new Vector3(-50f, 18f, 22.61218f),
            new Vector3(49.65339f, 18f, 0f),
            new Vector3(18.106f, -4.768372E-07f, 4.259981E-07f),
            new Vector3(18.106f, -4.768372E-07f, -12.3957f),
            new Vector3(18.12582f, 18f, -22.61218f),
            new Vector3(18.12582f, 18f, 22.61218f),
            new Vector3(18.106f, -2.861023E-06f, 12.3957f),
            new Vector3(18.106f, -4.768372E-07f, 4.259981E-07f),
            new Vector3(49.65339f, 18f, 0f),
            new Vector3(18.106f, -2.861023E-06f, 12.3957f),
            new Vector3(18.12582f, 18f, 22.61218f),
            new Vector3(-50f, 18f, 22.61218f),
            new Vector3(-23.98249f, -4.768371E-07f, 12.3957f),
            new Vector3(-50f, 18f, -22.61218f),
            new Vector3(-23.98249f, -4.768372E-07f, -12.3957f),
            new Vector3(-23.98249f, -4.768371E-07f, 12.3957f),
            new Vector3(-50f, 18f, 22.61218f),
            new Vector3(18.12582f, 18f, -22.61218f),
            new Vector3(18.106f, -4.768372E-07f, -12.3957f),
            new Vector3(-23.98249f, -4.768372E-07f, -12.3957f),
            new Vector3(-50f, 18f, -22.61218f),
            new Vector3(23.06379f, -35f, 17.35348f),
            new Vector3(23.06379f, -35f, -17.35349f),
            new Vector3(18.106f, -30.04222f, -12.3957f),
            new Vector3(18.106f, -30.04222f, 12.3957f),
            new Vector3(18.106f, -30.04222f, 12.3957f),
            new Vector3(-23.98249f, -30.04222f, 12.3957f),
            new Vector3(-28.94027f, -35f, 17.35348f),
            new Vector3(23.06379f, -35f, 17.35348f),
            new Vector3(-23.98249f, -30.04222f, 12.3957f),
            new Vector3(-23.98249f, -30.04222f, -12.3957f),
            new Vector3(-28.94027f, -35f, -17.35349f),
            new Vector3(-28.94027f, -35f, 17.35348f),
            new Vector3(-23.98249f, -30.04222f, -12.3957f),
            new Vector3(18.106f, -30.04222f, -12.3957f),
            new Vector3(23.06379f, -35f, -17.35349f),
            new Vector3(-28.94027f, -35f, -17.35349f),
            new Vector3(18.106f, -30.04222f, 12.3957f),
            new Vector3(18.106f, -2.861023E-06f, 12.3957f),
            new Vector3(-23.98249f, -4.768371E-07f, 12.3957f),
            new Vector3(-23.98249f, -30.04222f, 12.3957f),
            new Vector3(-23.98249f, -30.04222f, 12.3957f),
            new Vector3(-23.98249f, -4.768371E-07f, 12.3957f),
            new Vector3(-23.98249f, -4.768372E-07f, -12.3957f),
            new Vector3(-23.98249f, -30.04222f, -12.3957f),
            new Vector3(-23.98249f, -30.04222f, -12.3957f),
            new Vector3(-23.98249f, -4.768372E-07f, -12.3957f),
            new Vector3(18.106f, -4.768372E-07f, -12.3957f),
            new Vector3(18.106f, -30.04222f, -12.3957f),
            new Vector3(18.106f, -30.04222f, -12.3957f),
            new Vector3(18.106f, -4.768372E-07f, -12.3957f),
            new Vector3(18.106f, -4.768372E-07f, 4.259981E-07f),
            new Vector3(18.106f, -30.04222f, 12.3957f),
            new Vector3(18.106f, -2.861023E-06f, 12.3957f),
            new Vector3(50f, -39.49955f, 50f),
            new Vector3(50f, -39.49955f, -50f),
            new Vector3(45.50045f, -35f, -45.50045f),
            new Vector3(45.50045f, -35f, 45.50045f),
            new Vector3(45.50045f, -35f, 45.50045f),
            new Vector3(-45.50045f, -35f, 45.50045f),
            new Vector3(-50f, -39.49955f, 50f),
            new Vector3(50f, -39.49955f, 50f),
            new Vector3(50f, -39.49955f, -50f),
            new Vector3(-50f, -39.49955f, -50f),
            new Vector3(-45.50045f, -35f, -45.50045f),
            new Vector3(45.50045f, -35f, -45.50045f),
            new Vector3(-50f, -39.49955f, -50f),
            new Vector3(-50f, -39.49955f, 50f),
            new Vector3(-45.50045f, -35f, 45.50045f),
            new Vector3(-45.50045f, -35f, -45.50045f),
            new Vector3(50f, -50f, 50f),
            new Vector3(50f, -39.49955f, 50f),
            new Vector3(-50f, -39.49955f, 50f),
            new Vector3(-50f, -50f, 50f),
            new Vector3(50f, -39.49955f, -50f),
            new Vector3(50f, -50f, -50f),
            new Vector3(-50f, -50f, -50f),
            new Vector3(-50f, -39.49955f, -50f),
            new Vector3(50f, -39.49955f, 50f),
            new Vector3(50f, -50f, 50f),
            new Vector3(50f, -50f, -50f),
            new Vector3(50f, -39.49955f, -50f),
            new Vector3(-50f, -39.49955f, -50f),
            new Vector3(-50f, -50f, -50f),
            new Vector3(-50f, -50f, 50f),
            new Vector3(-50f, -39.49955f, 50f),
            new Vector3(-45.50045f, -35f, -45.50045f),
            new Vector3(23.06379f, -35f, -17.35349f),
            new Vector3(45.50045f, -35f, -45.50045f),
            new Vector3(-28.94027f, -35f, -17.35349f),
            new Vector3(23.06379f, -35f, 17.35348f),
            new Vector3(-45.50045f, -35f, 45.50045f),
            new Vector3(45.50045f, -35f, 45.50045f),
            new Vector3(-28.94027f, -35f, 17.35348f),
        };
        meshFilter.sharedMesh.triangles = new int[] {
            0, 1, 2,
            1, 3, 2,
            1, 4, 3,
            5, 6, 7,
            5, 7, 8,
            9, 10, 11,
            9, 11, 12,
            13, 14, 15,
            13, 15, 16,
            17, 18, 19,
            17, 19, 20,
            21, 22, 23,
            21, 23, 24,
            25, 26, 27,
            25, 27, 28,
            29, 30, 31,
            29, 31, 32,
            33, 34, 35,
            33, 35, 36,
            37, 38, 39,
            37, 39, 40,
            41, 42, 43,
            41, 43, 44,
            45, 46, 47,
            45, 47, 48,
            49, 50, 51,
            49, 51, 52,
            53, 54, 55,
            53, 55, 56,
            57, 58, 59,
            57, 59, 60,
            61, 62, 63,
            61, 63, 64,
            65, 66, 67,
            65, 67, 68,
            69, 70, 71,
            69, 71, 72,
            73, 74, 75,
            73, 75, 76,
            76, 75, 77,
            78, 79, 80,
            78, 80, 81,
            82, 83, 84,
            82, 84, 85,
            86, 87, 88,
            86, 88, 89,
            90, 91, 92,
            90, 92, 93,
            94, 95, 96,
            94, 96, 97,
            98, 99, 100,
            98, 100, 101,
            102, 103, 104,
            102, 104, 105,
            106, 107, 108,
            106, 108, 109,
            110, 111, 112,
            110, 113, 111,
            112, 111, 114,
            115, 113, 110,
            112, 114, 116,
            115, 117, 113,
            116, 114, 117,
            116, 117, 115,
        };
        meshFilter.sharedMesh.normals = new Vector3[] {
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0.5828154f, 0f, 0.8126045f),
            new Vector3(0.5828154f, 0f, 0.8126045f),
            new Vector3(0.5828154f, 0f, 0.8126045f),
            new Vector3(0.5828154f, 0f, 0.8126045f),
            new Vector3(0.5828153f, 0f, -0.8126045f),
            new Vector3(0.5828154f, 0f, -0.8126045f),
            new Vector3(0.5828154f, 0f, -0.8126045f),
            new Vector3(0.5828154f, 0f, -0.8126045f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0.5685596f, -0.6438626f, -0.5120362f),
            new Vector3(0.5685596f, -0.6438626f, -0.5120362f),
            new Vector3(0.5685596f, -0.6438626f, -0.5120362f),
            new Vector3(0.5685596f, -0.6438626f, -0.5120361f),
            new Vector3(0.5685596f, -0.6438625f, 0.5120362f),
            new Vector3(0.5685596f, -0.6438625f, 0.5120361f),
            new Vector3(0.5685596f, -0.6438625f, 0.5120361f),
            new Vector3(0.5685596f, -0.6438625f, 0.5120361f),
            new Vector3(0f, -0.4936153f, 0.8696803f),
            new Vector3(0f, -0.4936153f, 0.8696803f),
            new Vector3(0f, -0.4936153f, 0.8696803f),
            new Vector3(0f, -0.4936153f, 0.8696803f),
            new Vector3(-0.5689508f, -0.8223715f, 0f),
            new Vector3(-0.5689509f, -0.8223715f, 0f),
            new Vector3(-0.5689509f, -0.8223715f, 0f),
            new Vector3(-0.5689508f, -0.8223715f, 0f),
            new Vector3(0f, -0.4936154f, -0.8696803f),
            new Vector3(0f, -0.4936153f, -0.8696803f),
            new Vector3(0f, -0.4936153f, -0.8696803f),
            new Vector3(0f, -0.4936153f, -0.8696803f),
            new Vector3(0.7071066f, 0.7071069f, 0f),
            new Vector3(0.7071066f, 0.7071069f, 0f),
            new Vector3(0.7071066f, 0.7071069f, 0f),
            new Vector3(0.7071066f, 0.7071069f, 0f),
            new Vector3(0f, 0.707107f, 0.7071065f),
            new Vector3(0f, 0.707107f, 0.7071065f),
            new Vector3(0f, 0.707107f, 0.7071065f),
            new Vector3(0f, 0.707107f, 0.7071065f),
            new Vector3(-0.7071066f, 0.7071069f, 0f),
            new Vector3(-0.7071066f, 0.7071069f, 0f),
            new Vector3(-0.7071066f, 0.7071068f, 0f),
            new Vector3(-0.7071066f, 0.7071068f, 0f),
            new Vector3(0f, 0.7071071f, -0.7071065f),
            new Vector3(0f, 0.7071071f, -0.7071065f),
            new Vector3(0f, 0.7071071f, -0.7071065f),
            new Vector3(0f, 0.7071071f, -0.7071065f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(0.7071068f, 0.7071067f, 0f),
            new Vector3(0.7071068f, 0.7071067f, 0f),
            new Vector3(0.7071068f, 0.7071067f, 0f),
            new Vector3(0.7071068f, 0.7071067f, 0f),
            new Vector3(0f, 0.7071066f, 0.7071069f),
            new Vector3(0f, 0.7071066f, 0.7071069f),
            new Vector3(0f, 0.7071066f, 0.7071069f),
            new Vector3(0f, 0.7071066f, 0.7071069f),
            new Vector3(0f, 0.7071066f, -0.7071069f),
            new Vector3(0f, 0.7071066f, -0.7071069f),
            new Vector3(0f, 0.7071066f, -0.7071069f),
            new Vector3(0f, 0.7071066f, -0.7071069f),
            new Vector3(-0.7071068f, 0.7071067f, 0f),
            new Vector3(-0.7071068f, 0.7071067f, 0f),
            new Vector3(-0.7071068f, 0.7071067f, 0f),
            new Vector3(-0.7071068f, 0.7071067f, 0f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
        };
        meshFilter.sharedMesh.uv = new Vector2[] {
            new Vector2(0.05738842f, 0.7707383f),
            new Vector2(0.1138045f, 0.6920829f),
            new Vector2(0.0009764731f, 0.69208f),
            new Vector2(0.0009809136f, 0.5221158f),
            new Vector2(0.1138091f, 0.5221188f),
            new Vector2(0.1138184f, 0.1425306f),
            new Vector2(0.1138161f, 0.2393264f),
            new Vector2(0.1936515f, 0.2393284f),
            new Vector2(0.1936538f, 0.1425325f),
            new Vector2(0.1138206f, 0.04573471f),
            new Vector2(0.1138184f, 0.1425306f),
            new Vector2(0.1936538f, 0.1425325f),
            new Vector2(0.1936561f, 0.04573654f),
            new Vector2(0.1138045f, 0.6920829f),
            new Vector2(0.1936399f, 0.6920851f),
            new Vector2(0.1936445f, 0.5221209f),
            new Vector2(0.1138091f, 0.5221188f),
            new Vector2(0.1138119f, 0.4092906f),
            new Vector2(0.1138091f, 0.5221188f),
            new Vector2(0.1936445f, 0.5221209f),
            new Vector2(0.1936474f, 0.4092925f),
            new Vector2(0.1936515f, 0.2393284f),
            new Vector2(0.1138161f, 0.2393264f),
            new Vector2(0.1138119f, 0.4092906f),
            new Vector2(0.1936474f, 0.4092925f),
            new Vector2(0.1936538f, 0.1425325f),
            new Vector2(0.2578492f, 0.0785769f),
            new Vector2(0.2450808f, 0.05041039f),
            new Vector2(0.1936561f, 0.04573654f),
            new Vector2(0.1936515f, 0.2393284f),
            new Vector2(0.2450765f, 0.234657f),
            new Vector2(0.2578461f, 0.206491f),
            new Vector2(0.1936538f, 0.1425325f),
            new Vector2(0.2452882f, 0.239379f),
            new Vector2(0.1936515f, 0.2393284f),
            new Vector2(0.1936474f, 0.4092925f),
            new Vector2(0.2452856f, 0.3443838f),
            new Vector2(0.1936445f, 0.5221209f),
            new Vector2(0.2725753f, 0.4966342f),
            new Vector2(0.2725769f, 0.4347833f),
            new Vector2(0.1936474f, 0.4092925f),
            new Vector2(0.1936399f, 0.6920851f),
            new Vector2(0.2452767f, 0.692037f),
            new Vector2(0.2452795f, 0.5870323f),
            new Vector2(0.1936445f, 0.5221209f),
            new Vector2(0.3599209f, 0.07984026f),
            new Vector2(0.3241697f, 0.0009764656f),
            new Vector2(0.3133448f, 0.01946428f),
            new Vector2(0.3388822f, 0.07579714f),
            new Vector2(0.3202392f, 0.2393809f),
            new Vector2(0.3202367f, 0.3443857f),
            new Vector2(0.3377287f, 0.356755f),
            new Vector2(0.3377319f, 0.2270123f),
            new Vector2(0.347528f, 0.4347852f),
            new Vector2(0.3475264f, 0.4966362f),
            new Vector2(0.3650185f, 0.5090055f),
            new Vector2(0.3650207f, 0.4224166f),
            new Vector2(0.3202305f, 0.5870342f),
            new Vector2(0.3202277f, 0.692039f),
            new Vector2(0.3377198f, 0.7044085f),
            new Vector2(0.3377232f, 0.5746658f),
            new Vector2(0.3202392f, 0.2393809f),
            new Vector2(0.2452882f, 0.239379f),
            new Vector2(0.2452856f, 0.3443838f),
            new Vector2(0.3202367f, 0.3443857f),
            new Vector2(0.347528f, 0.4347852f),
            new Vector2(0.2725769f, 0.4347833f),
            new Vector2(0.2725753f, 0.4966342f),
            new Vector2(0.3475264f, 0.4966362f),
            new Vector2(0.3202305f, 0.5870342f),
            new Vector2(0.2452795f, 0.5870323f),
            new Vector2(0.2452767f, 0.692037f),
            new Vector2(0.3202277f, 0.692039f),
            new Vector2(0.3133448f, 0.01946428f),
            new Vector2(0.2450808f, 0.05041039f),
            new Vector2(0.2578492f, 0.0785769f),
            new Vector2(0.3388822f, 0.07579714f),
            new Vector2(0.270618f, 0.1067433f),
            new Vector2(0.6189883f, 0.0009800475f),
            new Vector2(0.3607796f, 0.000987282f),
            new Vector2(0.3754438f, 0.01588764f),
            new Vector2(0.6040787f, 0.01563898f),
            new Vector2(0.6040787f, 0.01563898f),
            new Vector2(0.60431f, 0.244317f),
            new Vector2(0.6189695f, 0.2592266f),
            new Vector2(0.6189883f, 0.0009800475f),
            new Vector2(0.3607796f, 0.000987282f),
            new Vector2(0.3607492f, 0.2591688f),
            new Vector2(0.3756531f, 0.2445048f),
            new Vector2(0.3754438f, 0.01588764f),
            new Vector2(0.3607492f, 0.2591688f),
            new Vector2(0.6189695f, 0.2592266f),
            new Vector2(0.60431f, 0.244317f),
            new Vector2(0.3756531f, 0.2445048f),
            new Vector2(0.6460264f, 0.0009811921f),
            new Vector2(0.6198292f, 0.0009800477f),
            new Vector2(0.6198183f, 0.2504656f),
            new Vector2(0.6460155f, 0.2504668f),
            new Vector2(0.6197965f, 0.7494368f),
            new Vector2(0.6459936f, 0.7494379f),
            new Vector2(0.6460046f, 0.4999524f),
            new Vector2(0.6198074f, 0.4999512f),
            new Vector2(0.6197856f, 0.9989224f),
            new Vector2(0.6459827f, 0.9989235f),
            new Vector2(0.6459936f, 0.7494379f),
            new Vector2(0.6197965f, 0.7494368f),
            new Vector2(0.6198074f, 0.4999512f),
            new Vector2(0.6460046f, 0.4999524f),
            new Vector2(0.6460155f, 0.2504668f),
            new Vector2(0.6198183f, 0.2504656f),
            new Vector2(0.3756531f, 0.2445048f),
            new Vector2(0.4462367f, 0.07222001f),
            new Vector2(0.3754438f, 0.01588764f),
            new Vector2(0.4462997f, 0.202829f),
            new Vector2(0.5334432f, 0.07212592f),
            new Vector2(0.60431f, 0.244317f),
            new Vector2(0.6040787f, 0.01563898f),
            new Vector2(0.5335267f, 0.2027325f),
        };
        meshRenderer.material = GetDefaultMaterial();
        DestroyImmediate(this);
    }
    private Material GetDefaultMaterial()
    {
        if(GraphicsSettings.renderPipelineAsset != null && GraphicsSettings.renderPipelineAsset.GetType().Name == "UniversalRenderPipelineAsset")
        {
            return new Material(Shader.Find("Universal Render Pipeline/Lit"));
        }
        else
        {
            return new Material(Shader.Find("Standard"));
        }
    }
}
public class YunquePreview : IMesh
{
    public Mesh Previsualize()
    {
       Mesh mesh = new Mesh();
       mesh.vertices = new Vector3[] {
            new Vector3(49.65339f, 50f, 0f),
            new Vector3(18.12582f, 50f, -22.61215f),
            new Vector3(18.12582f, 50f, 22.61215f),
            new Vector3(-50f, 50f, 22.61215f),
            new Vector3(-50f, 50f, -22.61215f),
            new Vector3(49.65339f, 50f, 0f),
            new Vector3(18.12582f, 50f, 22.61215f),
            new Vector3(18.12582f, 18f, 22.61218f),
            new Vector3(49.65339f, 18f, 0f),
            new Vector3(18.12582f, 50f, -22.61215f),
            new Vector3(49.65339f, 50f, 0f),
            new Vector3(49.65339f, 18f, 0f),
            new Vector3(18.12582f, 18f, -22.61218f),
            new Vector3(18.12582f, 50f, -22.61215f),
            new Vector3(18.12582f, 18f, -22.61218f),
            new Vector3(-50f, 18f, -22.61218f),
            new Vector3(-50f, 50f, -22.61215f),
            new Vector3(-50f, 50f, 22.61215f),
            new Vector3(-50f, 50f, -22.61215f),
            new Vector3(-50f, 18f, -22.61218f),
            new Vector3(-50f, 18f, 22.61218f),
            new Vector3(18.12582f, 18f, 22.61218f),
            new Vector3(18.12582f, 50f, 22.61215f),
            new Vector3(-50f, 50f, 22.61215f),
            new Vector3(-50f, 18f, 22.61218f),
            new Vector3(49.65339f, 18f, 0f),
            new Vector3(18.106f, -4.768372E-07f, 4.259981E-07f),
            new Vector3(18.106f, -4.768372E-07f, -12.3957f),
            new Vector3(18.12582f, 18f, -22.61218f),
            new Vector3(18.12582f, 18f, 22.61218f),
            new Vector3(18.106f, -2.861023E-06f, 12.3957f),
            new Vector3(18.106f, -4.768372E-07f, 4.259981E-07f),
            new Vector3(49.65339f, 18f, 0f),
            new Vector3(18.106f, -2.861023E-06f, 12.3957f),
            new Vector3(18.12582f, 18f, 22.61218f),
            new Vector3(-50f, 18f, 22.61218f),
            new Vector3(-23.98249f, -4.768371E-07f, 12.3957f),
            new Vector3(-50f, 18f, -22.61218f),
            new Vector3(-23.98249f, -4.768372E-07f, -12.3957f),
            new Vector3(-23.98249f, -4.768371E-07f, 12.3957f),
            new Vector3(-50f, 18f, 22.61218f),
            new Vector3(18.12582f, 18f, -22.61218f),
            new Vector3(18.106f, -4.768372E-07f, -12.3957f),
            new Vector3(-23.98249f, -4.768372E-07f, -12.3957f),
            new Vector3(-50f, 18f, -22.61218f),
            new Vector3(23.06379f, -35f, 17.35348f),
            new Vector3(23.06379f, -35f, -17.35349f),
            new Vector3(18.106f, -30.04222f, -12.3957f),
            new Vector3(18.106f, -30.04222f, 12.3957f),
            new Vector3(18.106f, -30.04222f, 12.3957f),
            new Vector3(-23.98249f, -30.04222f, 12.3957f),
            new Vector3(-28.94027f, -35f, 17.35348f),
            new Vector3(23.06379f, -35f, 17.35348f),
            new Vector3(-23.98249f, -30.04222f, 12.3957f),
            new Vector3(-23.98249f, -30.04222f, -12.3957f),
            new Vector3(-28.94027f, -35f, -17.35349f),
            new Vector3(-28.94027f, -35f, 17.35348f),
            new Vector3(-23.98249f, -30.04222f, -12.3957f),
            new Vector3(18.106f, -30.04222f, -12.3957f),
            new Vector3(23.06379f, -35f, -17.35349f),
            new Vector3(-28.94027f, -35f, -17.35349f),
            new Vector3(18.106f, -30.04222f, 12.3957f),
            new Vector3(18.106f, -2.861023E-06f, 12.3957f),
            new Vector3(-23.98249f, -4.768371E-07f, 12.3957f),
            new Vector3(-23.98249f, -30.04222f, 12.3957f),
            new Vector3(-23.98249f, -30.04222f, 12.3957f),
            new Vector3(-23.98249f, -4.768371E-07f, 12.3957f),
            new Vector3(-23.98249f, -4.768372E-07f, -12.3957f),
            new Vector3(-23.98249f, -30.04222f, -12.3957f),
            new Vector3(-23.98249f, -30.04222f, -12.3957f),
            new Vector3(-23.98249f, -4.768372E-07f, -12.3957f),
            new Vector3(18.106f, -4.768372E-07f, -12.3957f),
            new Vector3(18.106f, -30.04222f, -12.3957f),
            new Vector3(18.106f, -30.04222f, -12.3957f),
            new Vector3(18.106f, -4.768372E-07f, -12.3957f),
            new Vector3(18.106f, -4.768372E-07f, 4.259981E-07f),
            new Vector3(18.106f, -30.04222f, 12.3957f),
            new Vector3(18.106f, -2.861023E-06f, 12.3957f),
            new Vector3(50f, -39.49955f, 50f),
            new Vector3(50f, -39.49955f, -50f),
            new Vector3(45.50045f, -35f, -45.50045f),
            new Vector3(45.50045f, -35f, 45.50045f),
            new Vector3(45.50045f, -35f, 45.50045f),
            new Vector3(-45.50045f, -35f, 45.50045f),
            new Vector3(-50f, -39.49955f, 50f),
            new Vector3(50f, -39.49955f, 50f),
            new Vector3(50f, -39.49955f, -50f),
            new Vector3(-50f, -39.49955f, -50f),
            new Vector3(-45.50045f, -35f, -45.50045f),
            new Vector3(45.50045f, -35f, -45.50045f),
            new Vector3(-50f, -39.49955f, -50f),
            new Vector3(-50f, -39.49955f, 50f),
            new Vector3(-45.50045f, -35f, 45.50045f),
            new Vector3(-45.50045f, -35f, -45.50045f),
            new Vector3(50f, -50f, 50f),
            new Vector3(50f, -39.49955f, 50f),
            new Vector3(-50f, -39.49955f, 50f),
            new Vector3(-50f, -50f, 50f),
            new Vector3(50f, -39.49955f, -50f),
            new Vector3(50f, -50f, -50f),
            new Vector3(-50f, -50f, -50f),
            new Vector3(-50f, -39.49955f, -50f),
            new Vector3(50f, -39.49955f, 50f),
            new Vector3(50f, -50f, 50f),
            new Vector3(50f, -50f, -50f),
            new Vector3(50f, -39.49955f, -50f),
            new Vector3(-50f, -39.49955f, -50f),
            new Vector3(-50f, -50f, -50f),
            new Vector3(-50f, -50f, 50f),
            new Vector3(-50f, -39.49955f, 50f),
            new Vector3(-45.50045f, -35f, -45.50045f),
            new Vector3(23.06379f, -35f, -17.35349f),
            new Vector3(45.50045f, -35f, -45.50045f),
            new Vector3(-28.94027f, -35f, -17.35349f),
            new Vector3(23.06379f, -35f, 17.35348f),
            new Vector3(-45.50045f, -35f, 45.50045f),
            new Vector3(45.50045f, -35f, 45.50045f),
            new Vector3(-28.94027f, -35f, 17.35348f),
        };
        mesh.triangles = new int[] {
            0, 1, 2,
            1, 3, 2,
            1, 4, 3,
            5, 6, 7,
            5, 7, 8,
            9, 10, 11,
            9, 11, 12,
            13, 14, 15,
            13, 15, 16,
            17, 18, 19,
            17, 19, 20,
            21, 22, 23,
            21, 23, 24,
            25, 26, 27,
            25, 27, 28,
            29, 30, 31,
            29, 31, 32,
            33, 34, 35,
            33, 35, 36,
            37, 38, 39,
            37, 39, 40,
            41, 42, 43,
            41, 43, 44,
            45, 46, 47,
            45, 47, 48,
            49, 50, 51,
            49, 51, 52,
            53, 54, 55,
            53, 55, 56,
            57, 58, 59,
            57, 59, 60,
            61, 62, 63,
            61, 63, 64,
            65, 66, 67,
            65, 67, 68,
            69, 70, 71,
            69, 71, 72,
            73, 74, 75,
            73, 75, 76,
            76, 75, 77,
            78, 79, 80,
            78, 80, 81,
            82, 83, 84,
            82, 84, 85,
            86, 87, 88,
            86, 88, 89,
            90, 91, 92,
            90, 92, 93,
            94, 95, 96,
            94, 96, 97,
            98, 99, 100,
            98, 100, 101,
            102, 103, 104,
            102, 104, 105,
            106, 107, 108,
            106, 108, 109,
            110, 111, 112,
            110, 113, 111,
            112, 111, 114,
            115, 113, 110,
            112, 114, 116,
            115, 117, 113,
            116, 114, 117,
            116, 117, 115,
        };
        mesh.normals = new Vector3[] {
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0.5828154f, 0f, 0.8126045f),
            new Vector3(0.5828154f, 0f, 0.8126045f),
            new Vector3(0.5828154f, 0f, 0.8126045f),
            new Vector3(0.5828154f, 0f, 0.8126045f),
            new Vector3(0.5828153f, 0f, -0.8126045f),
            new Vector3(0.5828154f, 0f, -0.8126045f),
            new Vector3(0.5828154f, 0f, -0.8126045f),
            new Vector3(0.5828154f, 0f, -0.8126045f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0.5685596f, -0.6438626f, -0.5120362f),
            new Vector3(0.5685596f, -0.6438626f, -0.5120362f),
            new Vector3(0.5685596f, -0.6438626f, -0.5120362f),
            new Vector3(0.5685596f, -0.6438626f, -0.5120361f),
            new Vector3(0.5685596f, -0.6438625f, 0.5120362f),
            new Vector3(0.5685596f, -0.6438625f, 0.5120361f),
            new Vector3(0.5685596f, -0.6438625f, 0.5120361f),
            new Vector3(0.5685596f, -0.6438625f, 0.5120361f),
            new Vector3(0f, -0.4936153f, 0.8696803f),
            new Vector3(0f, -0.4936153f, 0.8696803f),
            new Vector3(0f, -0.4936153f, 0.8696803f),
            new Vector3(0f, -0.4936153f, 0.8696803f),
            new Vector3(-0.5689508f, -0.8223715f, 0f),
            new Vector3(-0.5689509f, -0.8223715f, 0f),
            new Vector3(-0.5689509f, -0.8223715f, 0f),
            new Vector3(-0.5689508f, -0.8223715f, 0f),
            new Vector3(0f, -0.4936154f, -0.8696803f),
            new Vector3(0f, -0.4936153f, -0.8696803f),
            new Vector3(0f, -0.4936153f, -0.8696803f),
            new Vector3(0f, -0.4936153f, -0.8696803f),
            new Vector3(0.7071066f, 0.7071069f, 0f),
            new Vector3(0.7071066f, 0.7071069f, 0f),
            new Vector3(0.7071066f, 0.7071069f, 0f),
            new Vector3(0.7071066f, 0.7071069f, 0f),
            new Vector3(0f, 0.707107f, 0.7071065f),
            new Vector3(0f, 0.707107f, 0.7071065f),
            new Vector3(0f, 0.707107f, 0.7071065f),
            new Vector3(0f, 0.707107f, 0.7071065f),
            new Vector3(-0.7071066f, 0.7071069f, 0f),
            new Vector3(-0.7071066f, 0.7071069f, 0f),
            new Vector3(-0.7071066f, 0.7071068f, 0f),
            new Vector3(-0.7071066f, 0.7071068f, 0f),
            new Vector3(0f, 0.7071071f, -0.7071065f),
            new Vector3(0f, 0.7071071f, -0.7071065f),
            new Vector3(0f, 0.7071071f, -0.7071065f),
            new Vector3(0f, 0.7071071f, -0.7071065f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(0.7071068f, 0.7071067f, 0f),
            new Vector3(0.7071068f, 0.7071067f, 0f),
            new Vector3(0.7071068f, 0.7071067f, 0f),
            new Vector3(0.7071068f, 0.7071067f, 0f),
            new Vector3(0f, 0.7071066f, 0.7071069f),
            new Vector3(0f, 0.7071066f, 0.7071069f),
            new Vector3(0f, 0.7071066f, 0.7071069f),
            new Vector3(0f, 0.7071066f, 0.7071069f),
            new Vector3(0f, 0.7071066f, -0.7071069f),
            new Vector3(0f, 0.7071066f, -0.7071069f),
            new Vector3(0f, 0.7071066f, -0.7071069f),
            new Vector3(0f, 0.7071066f, -0.7071069f),
            new Vector3(-0.7071068f, 0.7071067f, 0f),
            new Vector3(-0.7071068f, 0.7071067f, 0f),
            new Vector3(-0.7071068f, 0.7071067f, 0f),
            new Vector3(-0.7071068f, 0.7071067f, 0f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, 1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(0f, 0f, -1f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(-1f, 0f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
            new Vector3(0f, 1f, 0f),
        };
        mesh.uv = new Vector2[] {
            new Vector2(0.05738842f, 0.7707383f),
            new Vector2(0.1138045f, 0.6920829f),
            new Vector2(0.0009764731f, 0.69208f),
            new Vector2(0.0009809136f, 0.5221158f),
            new Vector2(0.1138091f, 0.5221188f),
            new Vector2(0.1138184f, 0.1425306f),
            new Vector2(0.1138161f, 0.2393264f),
            new Vector2(0.1936515f, 0.2393284f),
            new Vector2(0.1936538f, 0.1425325f),
            new Vector2(0.1138206f, 0.04573471f),
            new Vector2(0.1138184f, 0.1425306f),
            new Vector2(0.1936538f, 0.1425325f),
            new Vector2(0.1936561f, 0.04573654f),
            new Vector2(0.1138045f, 0.6920829f),
            new Vector2(0.1936399f, 0.6920851f),
            new Vector2(0.1936445f, 0.5221209f),
            new Vector2(0.1138091f, 0.5221188f),
            new Vector2(0.1138119f, 0.4092906f),
            new Vector2(0.1138091f, 0.5221188f),
            new Vector2(0.1936445f, 0.5221209f),
            new Vector2(0.1936474f, 0.4092925f),
            new Vector2(0.1936515f, 0.2393284f),
            new Vector2(0.1138161f, 0.2393264f),
            new Vector2(0.1138119f, 0.4092906f),
            new Vector2(0.1936474f, 0.4092925f),
            new Vector2(0.1936538f, 0.1425325f),
            new Vector2(0.2578492f, 0.0785769f),
            new Vector2(0.2450808f, 0.05041039f),
            new Vector2(0.1936561f, 0.04573654f),
            new Vector2(0.1936515f, 0.2393284f),
            new Vector2(0.2450765f, 0.234657f),
            new Vector2(0.2578461f, 0.206491f),
            new Vector2(0.1936538f, 0.1425325f),
            new Vector2(0.2452882f, 0.239379f),
            new Vector2(0.1936515f, 0.2393284f),
            new Vector2(0.1936474f, 0.4092925f),
            new Vector2(0.2452856f, 0.3443838f),
            new Vector2(0.1936445f, 0.5221209f),
            new Vector2(0.2725753f, 0.4966342f),
            new Vector2(0.2725769f, 0.4347833f),
            new Vector2(0.1936474f, 0.4092925f),
            new Vector2(0.1936399f, 0.6920851f),
            new Vector2(0.2452767f, 0.692037f),
            new Vector2(0.2452795f, 0.5870323f),
            new Vector2(0.1936445f, 0.5221209f),
            new Vector2(0.3599209f, 0.07984026f),
            new Vector2(0.3241697f, 0.0009764656f),
            new Vector2(0.3133448f, 0.01946428f),
            new Vector2(0.3388822f, 0.07579714f),
            new Vector2(0.3202392f, 0.2393809f),
            new Vector2(0.3202367f, 0.3443857f),
            new Vector2(0.3377287f, 0.356755f),
            new Vector2(0.3377319f, 0.2270123f),
            new Vector2(0.347528f, 0.4347852f),
            new Vector2(0.3475264f, 0.4966362f),
            new Vector2(0.3650185f, 0.5090055f),
            new Vector2(0.3650207f, 0.4224166f),
            new Vector2(0.3202305f, 0.5870342f),
            new Vector2(0.3202277f, 0.692039f),
            new Vector2(0.3377198f, 0.7044085f),
            new Vector2(0.3377232f, 0.5746658f),
            new Vector2(0.3202392f, 0.2393809f),
            new Vector2(0.2452882f, 0.239379f),
            new Vector2(0.2452856f, 0.3443838f),
            new Vector2(0.3202367f, 0.3443857f),
            new Vector2(0.347528f, 0.4347852f),
            new Vector2(0.2725769f, 0.4347833f),
            new Vector2(0.2725753f, 0.4966342f),
            new Vector2(0.3475264f, 0.4966362f),
            new Vector2(0.3202305f, 0.5870342f),
            new Vector2(0.2452795f, 0.5870323f),
            new Vector2(0.2452767f, 0.692037f),
            new Vector2(0.3202277f, 0.692039f),
            new Vector2(0.3133448f, 0.01946428f),
            new Vector2(0.2450808f, 0.05041039f),
            new Vector2(0.2578492f, 0.0785769f),
            new Vector2(0.3388822f, 0.07579714f),
            new Vector2(0.270618f, 0.1067433f),
            new Vector2(0.6189883f, 0.0009800475f),
            new Vector2(0.3607796f, 0.000987282f),
            new Vector2(0.3754438f, 0.01588764f),
            new Vector2(0.6040787f, 0.01563898f),
            new Vector2(0.6040787f, 0.01563898f),
            new Vector2(0.60431f, 0.244317f),
            new Vector2(0.6189695f, 0.2592266f),
            new Vector2(0.6189883f, 0.0009800475f),
            new Vector2(0.3607796f, 0.000987282f),
            new Vector2(0.3607492f, 0.2591688f),
            new Vector2(0.3756531f, 0.2445048f),
            new Vector2(0.3754438f, 0.01588764f),
            new Vector2(0.3607492f, 0.2591688f),
            new Vector2(0.6189695f, 0.2592266f),
            new Vector2(0.60431f, 0.244317f),
            new Vector2(0.3756531f, 0.2445048f),
            new Vector2(0.6460264f, 0.0009811921f),
            new Vector2(0.6198292f, 0.0009800477f),
            new Vector2(0.6198183f, 0.2504656f),
            new Vector2(0.6460155f, 0.2504668f),
            new Vector2(0.6197965f, 0.7494368f),
            new Vector2(0.6459936f, 0.7494379f),
            new Vector2(0.6460046f, 0.4999524f),
            new Vector2(0.6198074f, 0.4999512f),
            new Vector2(0.6197856f, 0.9989224f),
            new Vector2(0.6459827f, 0.9989235f),
            new Vector2(0.6459936f, 0.7494379f),
            new Vector2(0.6197965f, 0.7494368f),
            new Vector2(0.6198074f, 0.4999512f),
            new Vector2(0.6460046f, 0.4999524f),
            new Vector2(0.6460155f, 0.2504668f),
            new Vector2(0.6198183f, 0.2504656f),
            new Vector2(0.3756531f, 0.2445048f),
            new Vector2(0.4462367f, 0.07222001f),
            new Vector2(0.3754438f, 0.01588764f),
            new Vector2(0.4462997f, 0.202829f),
            new Vector2(0.5334432f, 0.07212592f),
            new Vector2(0.60431f, 0.244317f),
            new Vector2(0.6040787f, 0.01563898f),
            new Vector2(0.5335267f, 0.2027325f),
        };
        return mesh;
    }
}
