using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class Container : MonoBehaviour
{


    public Vector3 ContainerPosition;
    public float ReloadCoolDown = 0;

    public SerialisedDictionary<Vector3, Voxel> data;
    public List<Voxel> solidData = new List<Voxel>();
    public MeshData meshData = new MeshData();

    MeshCollider meshCollider;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    public void Initialize(Material mat, Vector3 position)
    {
        ConfigureComponents();
        data = new SerialisedDictionary<Vector3, Voxel>();
        meshRenderer.sharedMaterial = mat;
        ContainerPosition = position;
    }
    public void ClearData()
    {
        data.Clear();
    }

    private void ConfigureComponents()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
    }
    public void GenerateMesh()
    {
        meshData.ClearData();
        solidData.Clear();

        Vector3 blockPos;
        Voxel block;

        int counter = 0;

        Vector3[] faceVertices = new Vector3[4];
        Vector2[] faceUVs = new Vector2[4];

        VoxelColor voxelColor;
        Color voxelColorAlpha;
        Vector2 voxelSmootness;

        foreach (var kvp in data.Keys)
        {
            if (data.Get(kvp).Id == 0) continue;
            blockPos = kvp;
            block = data.Get(kvp);
            block.WorldPos = kvp;
            solidData.Add(block);


            voxelColor = WorldManager.instance.WorldColors[block.Id - 1];

            voxelColorAlpha = voxelColor.color;

            if (block.isTransparent)
            {

                voxelColorAlpha.a = 0.3f;
            }
            else
            {
                voxelColorAlpha.a = 1;
            }


            voxelSmootness = new Vector2(voxelColor.metallic, voxelColor.Smoothness);




            for (int i = 0; i < 6; i++)
            {
                if (this[blockPos].Id == this[blockPos + voxelFaceChecks[i]].Id)
                {
                    if (this[blockPos + voxelFaceChecks[i]].isSolid) continue;
                }
                


                if (blockPos.x % 10 == 0 && i == 2)
                {

                    //-x

                    if (WorldManager.instance.container.ContainsKey(ContainerPosition + ChunckCheck[2]))
                    {

                        if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[2]).data.ContainsKey(new Vector3(blockPos.x - 1, blockPos.y, blockPos.z)))
                        {

                            if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[2]).data.Get(new Vector3(blockPos.x - 1, blockPos.y, blockPos.z)).isSolid)
                            {

                                continue;
                            }
                        }


                    }

                }
                //x
                if (blockPos.x % 10 == 9 && i == 3)
                {

                    if (WorldManager.instance.container.ContainsKey(ContainerPosition + ChunckCheck[3]))
                    {
                        Vector3 v = ContainerPosition + ChunckCheck[3];

                        if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[3]).data.ContainsKey(new Vector3(blockPos.x + 1, blockPos.y, blockPos.z)))
                        {

                            if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[3]).data.Get(new Vector3(blockPos.x + 1, blockPos.y, blockPos.z)).isSolid)
                            {

                                continue;
                            }
                        }

                    }
                }
                //z
                if (blockPos.z % 10 == 0 && i == 0)
                {

                    if (WorldManager.instance.container.ContainsKey(ContainerPosition + ChunckCheck[0]))
                    {
                        Vector3 v = ContainerPosition + ChunckCheck[0];

                        if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[0]).data.ContainsKey(new Vector3(blockPos.x, blockPos.y, blockPos.z - 1)))
                        {

                            if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[0]).data.Get(new Vector3(blockPos.x, blockPos.y, blockPos.z - 1)).isSolid)
                            {

                                continue;
                            }
                        }


                    }
                }
                //+z = 1 
                if (blockPos.z % 10 == 9 && i == 1)
                {

                    if (WorldManager.instance.container.ContainsKey(ContainerPosition + ChunckCheck[1]))
                    {
                        Vector3 v = ContainerPosition + ChunckCheck[1];

                        if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[1]).data.ContainsKey(new Vector3(blockPos.x, blockPos.y, blockPos.z + 1)))
                        {

                            if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[1]).data.Get(new Vector3(blockPos.x, blockPos.y, blockPos.z + 1)).isSolid)
                            {

                                continue;
                            }
                        }

                    }
                }



                for (int j = 0; j < 4; j++)
                {
                    faceVertices[j] = voxelVertices[voxelVertexIndex[i, j]] + blockPos;
                    faceUVs[j] = voxelUVs[j];
                }
                for (int j = 0; j < 6; j++)
                {
                    meshData.vertices.Add(faceVertices[voxelTris[i, j]]);
                    meshData.UVs.Add(faceUVs[voxelTris[i, j]]);

                    meshData.colors.Add(voxelColorAlpha);
                    meshData.UVs2.Add(voxelSmootness);

                    meshData.triangles.Add(counter++);
                }
            }
        }
    }
    public void ReloadColorsWithCoolDown()
    {

        if (ReloadCoolDown < 1.5f)
        {
            DefaultColors();
            ReloadColors();
            ReloadCoolDown = 1.5f;
        }
        else if (ReloadCoolDown > 1.5f ) 
        {
            ReloadCoolDown -= Time.fixedDeltaTime;
        }
        if (ReloadCoolDown >= 2)
        {
            ReloadColors();
        }
    }
    public void DefaultColors()
    {
        List<Voxel> TransparencyData = new List<Voxel>();
        foreach (Voxel v in solidData)
        {
            var vox = v;
            vox.isTransparent = false;
            TransparencyData.Add(vox);

        }
        solidData=TransparencyData;
    }
    public void ReloadColors()
    {
        meshData.colors = new List<Color>();
        meshData.colors.Clear();
        meshData.mesh.Clear();
        Vector3 blockPos;
        Voxel block;

        VoxelColor voxelColor;
        Color voxelColorAlpha;
        
        
        
        foreach (var kvp in solidData)
        {
            
            blockPos = kvp.WorldPos;
            block = kvp;
            

            voxelColor = WorldManager.instance.WorldColors[block.Id - 1];

            voxelColorAlpha = voxelColor.color;

            if (block.isTransparent)
            {

                voxelColorAlpha.a = 0.3f;
            }
            else
            {
                voxelColorAlpha.a = 1;

            }

            for (int i = 0; i < 6; i++)
            {
                if (this[blockPos + voxelFaceChecks[i]].isSolid) continue;


                if (blockPos.x % 10 == 0 && i == 2)
                {

                    //-x

                    if (WorldManager.instance.container.ContainsKey(ContainerPosition + ChunckCheck[2]))
                    {

                        if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[2]).data.ContainsKey(new Vector3(blockPos.x - 1, blockPos.y, blockPos.z)))
                        {

                            if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[2]).data.Get(new Vector3(blockPos.x - 1, blockPos.y, blockPos.z)).isSolid)
                            {

                                continue;
                            }
                        }


                    }

                }
                //x
                if (blockPos.x % 10 == 9 && i == 3)
                {

                    if (WorldManager.instance.container.ContainsKey(ContainerPosition + ChunckCheck[3]))
                    {
                        Vector3 v = ContainerPosition + ChunckCheck[3];

                        if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[3]).data.ContainsKey(new Vector3(blockPos.x + 1, blockPos.y, blockPos.z)))
                        {

                            if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[3]).data.Get(new Vector3(blockPos.x + 1, blockPos.y, blockPos.z)).isSolid)
                            {

                                continue;
                            }
                        }

                    }
                }
                //z
                if (blockPos.z % 10 == 0 && i == 0)
                {

                    if (WorldManager.instance.container.ContainsKey(ContainerPosition + ChunckCheck[0]))
                    {
                        Vector3 v = ContainerPosition + ChunckCheck[0];

                        if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[0]).data.ContainsKey(new Vector3(blockPos.x, blockPos.y, blockPos.z - 1)))
                        {

                            if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[0]).data.Get(new Vector3(blockPos.x, blockPos.y, blockPos.z - 1)).isSolid)
                            {

                                continue;
                            }
                        }


                    }
                }
                //+z = 1 
                if (blockPos.z % 10 == 9 && i == 1)
                {

                    if (WorldManager.instance.container.ContainsKey(ContainerPosition + ChunckCheck[1]))
                    {
                        Vector3 v = ContainerPosition + ChunckCheck[1];

                        if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[1]).data.ContainsKey(new Vector3(blockPos.x, blockPos.y, blockPos.z + 1)))
                        {

                            if (WorldManager.instance.container.Get(ContainerPosition + ChunckCheck[1]).data.Get(new Vector3(blockPos.x, blockPos.y, blockPos.z + 1)).isSolid)
                            {

                                continue;
                            }
                        }

                    }
                }

                
                for (int j = 0; j < 6; j++)
                {
                   
                    meshData.colors.Add(voxelColorAlpha);
                    
                }
            }
           




        }
        UploadMesh();


        

        
        
    }

    public void UploadMesh()
    {
        meshData.UploadMesh();

        if (meshRenderer == null)
        {
            ConfigureComponents();
        }
        meshFilter.mesh = meshData.mesh;
        if (meshData.vertices.Count > 3)
        {
            meshCollider.sharedMesh = meshData.mesh;
        }
    }
    [ContextMenu("ReloadChunk")]
    public void ReloadChunck()
    {
        GenerateMesh();
        UploadMesh();
    }
    public Voxel this[Vector3 index]
    {
        get
        {
            if (data.ContainsKey(index))
                return data.Get(index);
            else
                return emptyVoxel;
        }
        set
        {
            if (data.ContainsKey(index))
            {
                data.Set(index, value);
            }
            else
                data.Add(index, value);
        }
    }
    public static Voxel emptyVoxel = new Voxel() { Id = 0 };

    #region MeshData

    [System.Serializable]
    public struct MeshData
    {
        public Mesh mesh;
        public List<Vector3> vertices;
        public List<int> triangles;
        public List<Vector2> UVs;
        public List<Vector2> UVs2;
        public List<Color> colors;

        public bool Initialized;

        public void ClearData()
        {
            if (!Initialized)
            {
                vertices = new List<Vector3>();
                triangles = new List<int>();
                UVs = new List<Vector2>();
                UVs2 = new List<Vector2>();
                colors = new List<Color>();


                Initialized = true;
                mesh = new Mesh();
            }
            else
            {
                vertices.Clear();
                triangles.Clear();
                UVs.Clear();
                UVs2.Clear();
                colors.Clear();
                mesh.Clear();
            }
        }
        public void UploadMesh(bool sharedVertices = false)
        {
            mesh.SetVertices(vertices);
            mesh.SetTriangles(triangles, 0, false);
            mesh.SetColors(colors);
            mesh.SetUVs(2, UVs2);
            mesh.SetUVs(0, UVs);

            mesh.Optimize();

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            mesh.UploadMeshData(false);
        }
    }

    #endregion
    #region VoxelStatics
    static readonly Vector3[] voxelVertices = new Vector3[8]
    {
        new Vector3(0,0,0),//0
        new Vector3(1,0,0),//1
        new Vector3(0,1,0),//2
        new Vector3(1,1,0),//3

        new Vector3(0,0,1),//4
        new Vector3(1,0,1),//5
        new Vector3(0,1,1),//6
        new Vector3(1,1,1) //7

    };
    public static readonly int[,] voxelVertexIndex = new int[6, 4]
    {
        {0,1,2,3},
        {4,5,6,7},
        {4,0,6,2},
        {5,1,7,3},
        {0,1,4,5},
        {2,3,6,7}
    };
    public static readonly int[,] voxelTris = new int[6, 6]
    {
        {0,2,3,0,3,1},
        {0,1,2,1,3,2},
        {0,2,3,0,3,1},
        {0,1,2,1,3,2},
        {0,1,2,1,3,2},
        {0,2,3,0,3,1}
    };
    public static readonly Vector2[] voxelUVs = new Vector2[4]
    {
        new Vector2(0,0),
        new Vector2(0,1),
        new Vector2(1,0),
        new Vector2(1,1)
    };
    static readonly Vector3[] voxelFaceChecks = new Vector3[6]
    {
        new Vector3(0,0,-1),//back
        new Vector3(0,0,1),//front
        new Vector3(-1,0,0),//left
        new Vector3(1,0,0),//right
        new Vector3(0,-1,0),//bottom
        new Vector3(0,1,0)//top
    };
    static readonly Vector3[] ChunckCheck = new Vector3[4]
  {
        new Vector3(0,0,-1),//back
        new Vector3(0,0,1),//front
        new Vector3(-1,0,0),//left
        new Vector3(1,0,0),//right
  };




    #endregion
}
