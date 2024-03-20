using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WorldManager))]
public class WorldManagerEditor : Editor
{

    private void OnSceneGUI()
    {

        WorldManager manager = (WorldManager)target;

        Handles.color = Color.white;


        foreach (var kvp in manager.container.data.Keys)
        {
            Vector3 voxelCenter = new Vector3(kvp.x + 0.5f, kvp.y + 0.5f, kvp.z + 0.5f);
            if (manager.container.data.Get(kvp).isSolid)
            {
                #region Z
                //-z
                if (!manager.container[kvp + voxelFaceChecks[0]].isSolid && VoxelButonsVar.Z == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0, 0, -0.5f), Quaternion.identity, 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp + new Vector3(0, 0, -1), new Voxel() { Id = VoxelButonsVar.BlockID });
                            manager.ReloadTerrain();
                        }
                    }
                    else
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0, 0, -0.5f), Quaternion.identity, 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp, Container.emptyVoxel);
                            manager.ReloadTerrain();
                        }
                    }
                }
                //+z
                if (!manager.container[kvp + voxelFaceChecks[1]].isSolid && VoxelButonsVar.Z1 == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0, 0, +0.5f), Quaternion.identity, 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp + new Vector3(0, 0, 1), new Voxel() { Id = VoxelButonsVar.BlockID });
                            manager.ReloadTerrain();
                        }
                    }
                    else
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0, 0, +0.5f), Quaternion.identity, 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp, Container.emptyVoxel);
                            manager.ReloadTerrain();
                        }
                    }
                }
                #endregion
                #region X
                //-x
                if (!manager.container[kvp + voxelFaceChecks[2]].isSolid && VoxelButonsVar.X == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(-0.5f, 0, 0), Quaternion.Euler(0, 90, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp + new Vector3(-1, 0, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                            manager.ReloadTerrain();
                        }
                    }
                    else
                    {
                        if (Handles.Button(voxelCenter + new Vector3(-0.5f, 0, 0), Quaternion.Euler(0, 90, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp, Container.emptyVoxel);
                            manager.ReloadTerrain();
                        }
                    }
                }
                //+x
                if (!manager.container[kvp + voxelFaceChecks[3]].isSolid && VoxelButonsVar.X1 == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0.5f, 0, 0), Quaternion.Euler(0, 90, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp + new Vector3(1, 0, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                            manager.ReloadTerrain();
                        }
                    }
                    else
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0.5f, 0, 0), Quaternion.Euler(0, 90, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp, Container.emptyVoxel);
                            manager.ReloadTerrain();
                        }
                    }
                }
                #endregion
                #region Y
                //-y
                if (!manager.container[kvp + voxelFaceChecks[4]].isSolid && VoxelButonsVar.Y == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0, -0.5f, 0), Quaternion.Euler(90, 0, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp + new Vector3(0, -1, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                            manager.ReloadTerrain();
                        }
                    }
                    else
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0, -0.5f, 0), Quaternion.Euler(90, 0, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp, Container.emptyVoxel);
                            manager.ReloadTerrain();
                        }
                    }
                }
                //+y
                if (!manager.container[kvp + voxelFaceChecks[5]].isSolid && VoxelButonsVar.Y1 == true)
                {
                    if (VoxelButonsVar.TogleConstruct)
                    {
                        if (Handles.Button(voxelCenter + new Vector3(0, 0.5f, 0), Quaternion.Euler(90, 0, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            if (manager.container.data.ContainsKey(kvp + new Vector3(0, 1, 0)))
                            {
                                Debug.Log("set");
                                manager.container.data.Set(kvp + new Vector3(0, 1, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                                manager.ReloadTerrain();
                            }
                            else
                            {
                                manager.container.data.Add(kvp + new Vector3(0, 1, 0), new Voxel() { Id = VoxelButonsVar.BlockID });
                                manager.ReloadTerrain();
                            }
                        }
                    }
                    else
                    {

                        if (Handles.Button(voxelCenter + new Vector3(0, 0.5f, 0), Quaternion.Euler(90, 0, 0), 0.5f, 0.5f, Handles.RectangleHandleCap))
                        {
                            manager.container.data.Set(kvp, Container.emptyVoxel);
                            manager.ReloadTerrain();
                        }
                    }
                }
                #endregion
                //
            }

        }

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

