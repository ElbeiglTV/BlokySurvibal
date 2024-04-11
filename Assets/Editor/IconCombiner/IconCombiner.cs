using UnityEngine;
using UnityEditor;
using System.IO;

public class IconCombiner : EditorWindow
{
    [MenuItem("Tools/Combine Icons")]
    public static void CombineIcons()
    {
        // Cargar los dos iconos que quieres combinar
        Texture2D icon1 = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
        Texture2D icon2 = EditorGUIUtility.IconContent("MeshRenderer Icon").image as Texture2D;

        // Ajustar el tamaño de ambas texturas para que tengan las mismas dimensiones
        int width = Mathf.Max(icon1.width, icon2.width);
        int height = Mathf.Max(icon1.height, icon2.height);
        icon1 = ResizeTexture(icon1, width, height);
        icon2 = ResizeTexture(icon2, width, height);

        // Dividir una de las texturas a la mitad
        Texture2D halfIcon1 = CropTexture(icon1, 0, 0, width / 2, height);
        Texture2D halfIcon2 = CropTexture(icon2, width/2, 0, width / 2, height);

        // Combinar las dos mitades en una sola textura
        Texture2D combinedIcon = new Texture2D(width, height);
        combinedIcon.SetPixels32(0, 0, width / 2, height, halfIcon1.GetPixels32());
        combinedIcon.SetPixels32(width / 2, 0, width / 2, height, halfIcon2.GetPixels32());

        // Aplicar los cambios y guardar la textura combinada
        combinedIcon.Apply();

        // Guardar la textura combinada en una ubicación específica
        string path = "Assets/Editor/CombinedIcon.png";
        byte[] bytes = combinedIcon.EncodeToPNG();
        File.WriteAllBytes(path, bytes);

        // Refrescar el Asset Database para que Unity reconozca la nueva textura
        AssetDatabase.Refresh();
        Debug.Log("Combined icon saved to: " + path);
    }
    [MenuItem("Tools/Obtain Icons")]
    public static void ObtainIcons()
    {
        // Cargar los dos iconos que quieres combinar
        Texture2D icon1 = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
        Texture2D icon2 = EditorGUIUtility.IconContent("MeshFilter Icon").image as Texture2D;

        // Ajustar el tamaño de ambas texturas para que tengan las mismas dimensiones
        int width = Mathf.Max(icon1.width, icon2.width);
        int height = Mathf.Max(icon1.height, icon2.height);
        icon1 = ResizeTexture(icon1, width, height);
        icon2 = ResizeTexture(icon2, width, height);

        

        // Guardar la textura combinada en una ubicación específica
        string path = "Assets/Editor/cs Script Icon.png";
        string path2 = "Assets/Editor/MeshFilter Icon.png";

        byte[] bytes = icon1.EncodeToPNG();
        byte[] bytes2 = icon2.EncodeToPNG();
        File.WriteAllBytes(path, bytes);
        File.WriteAllBytes(path2, bytes2);

        // Refrescar el Asset Database para que Unity reconozca la nueva textura
        AssetDatabase.Refresh();
        Debug.Log("Combined icon saved to: " + path);
    }

    private static Texture2D ResizeTexture(Texture2D texture, int width, int height)
    {
        RenderTexture rt = RenderTexture.GetTemporary(width, height);
        Graphics.Blit(texture, rt);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = rt;
        Texture2D resizedTexture = new Texture2D(width, height);
        resizedTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        resizedTexture.Apply();
        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(rt);
        return resizedTexture;
    }

    private static Texture2D CropTexture(Texture2D texture, int x, int y, int width, int height)
    {
        Color[] pixels = texture.GetPixels(x, y, width, height);
        Texture2D croppedTexture = new Texture2D(width, height);
        croppedTexture.SetPixels(pixels);
        return croppedTexture;
    }
}
