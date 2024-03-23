using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance;

    public Vector2 GridSize;

    public Material worldMaterial;
    public SerialisedDictionary<Vector3,Container> container;

    public VoxelColor[] WorldColors;
    public VoxelTexture[] WorldTextures;

    // Start is called before the first frame update
    
    [ContextMenu("GenerateDefaultTerrain")]
    public void GenerateDefaultTerrain()
    {
        GameObject cont = new GameObject("Container");
        cont.transform.parent = transform;
        var _container = cont.AddComponent<Container>();
        container.Add(new Vector3(0,0,0),_container);
        _container.Initialize(worldMaterial, Vector3.zero);

        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                int heigth = 20;
                for (int y = 0; y < heigth; y++)
                {
                    if (y < 2)
                    {
                        _container[new Vector3(x, y, z)] = new Voxel() { Id = 1 };

                    }
                    else
                    {
                        _container[new Vector3(x, y, z)] = new Voxel() { Id = 0 };
                    }
                }




            }


        }

        _container.GenerateMesh();
        _container.UploadMesh();
    }
    //sobrecarga
    public void GenerateDefaultTerrain(int xx, int zz)
    {
        GameObject cont = new GameObject("Container");
        cont.transform.parent = transform;
        var _container = cont.AddComponent<Container>();
        container.Add(new Vector3(xx, 0,zz), _container);
        _container.Initialize(worldMaterial, Vector3.zero);
        _container.ContainerPosition = new Vector3(xx,0,zz);
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                int heigth = 20;
                for (int y = 0; y < heigth; y++)
                {
                    if (y < 2)
                    {
                        _container[new Vector3(x + (10 * xx), y, z + (10 * zz))] = new Voxel() { Id = 1 };
                        

                    }
                    else
                    {
                        _container[new Vector3(x + (10 * xx), y, z + (10 * zz))] = new Voxel() { Id = 0 };
                        
                    }
                }




            }


        }

        _container.GenerateMesh();
        _container.UploadMesh();
    }
    [ContextMenu("GenerateGrid")]
    public void GenerateGrid()
    {
        container.Clear();
        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {

                GenerateDefaultTerrain(x, y);

            }
        }
    }


    [ContextMenu("ReloadGrid")]
    public void ReloadGrid()
    {
        
        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {
                Container cont = null;
                foreach(Container c in container.Values)
                {
                    if(c.ContainerPosition.x == x && c.ContainerPosition.z == y )
                    {
                        cont= c;
                    }
                }
                if( cont == null)
                {

                    GenerateDefaultTerrain(x, y);
                }
                
                
            }
        }
    }


    [ContextMenu("ReloadTerrain")]
    public void ReloadTerrain()
    {
        foreach (Container c in container.Values)
        {
            c.GenerateMesh();
            c.UploadMesh();
        }

    }
    


    private void OnValidate()
    {
        instance = this;
    }


}
