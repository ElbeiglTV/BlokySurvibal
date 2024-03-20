using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Container))]
public class ContainerEditor : Editor
{

    private void OnSceneGUI()
    {

        Container container = (Container)target;
        WorldManager manager = WorldManager.instance;

        Handles.color = Color.white;


        foreach (var kvp in container.data.Keys)
        {
            Vector3 voxelCenter = new Vector3(kvp.x + 0.5f, kvp.y + 0.5f, kvp.z + 0.5f)+container.transform.position;
            if (container.data.Get(kvp).isSolid)
            {
                #region Z
                //-z
                if (!container[kvp + voxelFaceChecks[0]].isSolid && VoxelButonsVar.Z == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0, 0, -0.5f), Quaternion.identity, 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp + new Vector3(0, 0, -1), new Voxel() { Id = VoxelButonsVar.BlockID });
                            ReloadChunck(container);
                        }
                    }
                    else
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0, 0, -0.5f), Quaternion.identity, 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp, Container.emptyVoxel);
                            ReloadChunck(container);
                        }
                    }
                }
                //+z
                if (!container[kvp + voxelFaceChecks[1]].isSolid && VoxelButonsVar.Z1 == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0, 0, +0.5f), Quaternion.identity, 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp + new Vector3(0, 0, 1), new Voxel() { Id = VoxelButonsVar.BlockID });
                            ReloadChunck(container);
                        }
                    }
                    else
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0, 0, +0.5f), Quaternion.identity, 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp, Container.emptyVoxel);
                            ReloadChunck(container);
                        }
                    }
                }
                #endregion
                #region X
                //-x
                if (!container[kvp + voxelFaceChecks[2]].isSolid && VoxelButonsVar.X == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(-0.5f, 0, 0), Quaternion.Euler(0, 90, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp + new Vector3(-1, 0, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                            ReloadChunck(container);
                        }
                    }
                    else
                    {
                        if (Handles.Button(voxelCenter + new Vector3(-0.5f, 0, 0), Quaternion.Euler(0, 90, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp, Container.emptyVoxel);
                            ReloadChunck(container);
                        }
                    }
                }
                //+x
                if (!container[kvp + voxelFaceChecks[3]].isSolid && VoxelButonsVar.X1 == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0.5f, 0, 0), Quaternion.Euler(0, 90, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp + new Vector3(1, 0, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                            ReloadChunck(container);
                        }
                    }
                    else
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0.5f, 0, 0), Quaternion.Euler(0, 90, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp, Container.emptyVoxel);
                            ReloadChunck(container);
                        }
                    }
                }
                #endregion
                #region Y
                //-y
                if (!container[kvp + voxelFaceChecks[4]].isSolid && VoxelButonsVar.Y == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0, -0.5f, 0), Quaternion.Euler(90, 0, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp + new Vector3(0, -1, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                            ReloadChunck(container);
                        }
                    }
                    else
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0, -0.5f, 0), Quaternion.Euler(90, 0, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp, Container.emptyVoxel);
                            ReloadChunck(container);
                        }
                    }
                }
                //+y
                if (!container[kvp + voxelFaceChecks[5]].isSolid && VoxelButonsVar.Y1 == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0, 0.5f, 0), Quaternion.Euler(90, 0, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            if (container.data.ContainsKey(kvp + new Vector3(0, 1, 0)))
                            {
                                Debug.Log("set");
                                container.data.Set(kvp + new Vector3(0, 1, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                                ReloadChunck(container);
                            }
                            else
                            {
                                container.data.Add(kvp + new Vector3(0, 1, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                                ReloadChunck(container);
                            }
                        }
                    }
                    else
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0, 0.5f, 0), Quaternion.Euler(90, 0, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            container.data.Set(kvp, Container.emptyVoxel);
                            ReloadChunck(container);
                        }
                    }
                }
                #endregion
                //
            }

        }

    }
    public void ReloadChunck(Container c)
    {
        c.GenerateMesh();
        c.UploadMesh();
    }
    static readonly Vector3[] voxelFaceChecks = new Vector3[6]
    {
        new Vector3(0,0,-1),//back
        new Vector3(0,0,1),//front
        new Vector3(-1,0,0),//left
        new Vector3(1,0,0),//right
        new Vector3(0,-1,0),//bottom
        new Vector3(0,1,0)//top
    };
}

