using Unity.VisualScripting;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance;


    public Material worldMaterial;
    public Container container;

    public VoxelColor[] WorldColors;
    public VoxelTexture[] WorldTextures;
  
    // Start is called before the first frame update
    void Start()
    {
        GenerateDefaultTerrain();
    }
    [ContextMenu("GenerateDefaultTerrain")]
    public void GenerateDefaultTerrain()
    {
        GameObject cont = new GameObject("Container");
        cont.transform.parent = transform;
        container = cont.AddComponent<Container>();
        container.Initialize(worldMaterial, Vector3.zero);

        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                int heigth = 20;
                for (int y = 0; y < heigth; y++)
                {
                    if (y < 2)
                    {
                        container[new Vector3(x, y, z)] = new Voxel() { Id = 1 };

                    }
                    else
                    {
                        container[new Vector3(x, y, z)] = new Voxel() { Id = 0 };
                    }
                }




            }


        }

        container.GenerateMesh();
        container.UploadMesh();
    }
    [ContextMenu("ReloadTerrain")]
    public void ReloadTerrain()
    {
        container.GenerateMesh();
        ReloadTextures();
        container.UploadMesh();
    }
    public void ReloadTextures()
    {
        worldMaterial.SetTexture("_Texture2DArray", GenerateTextureArray());
    }
    private void OnValidate()
    {
        instance = this;
    }
    public Texture2DArray GenerateTextureArray() 
    { 
      if(WorldTextures.Length > 0)
        {
            Texture2D tex = WorldTextures[0].texture;
            Texture2DArray texArrayAlbedo = new Texture2DArray(tex.width, tex.height, WorldTextures.Length, tex.format, tex.mipmapCount > 1);
            texArrayAlbedo.anisoLevel = tex.anisoLevel;
            texArrayAlbedo.filterMode = tex.filterMode;
            texArrayAlbedo.wrapMode = tex.wrapMode;

            for(int i = 0; i < WorldTextures.Length; i++)
            {
                Graphics.CopyTexture(WorldTextures[i].texture, 0, 0, texArrayAlbedo, i, 0);
            } 
            return texArrayAlbedo;
        }
      return null;
    
    
    }

}
