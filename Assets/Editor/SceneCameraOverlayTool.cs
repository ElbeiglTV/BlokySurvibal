using Codice.CM.Client.Gui;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SceneCameraOverlayTool
{
    static SceneCameraOverlayTool()
    {
        // Suscribirse al evento de manejo de la vista de la escena
        SceneView.duringSceneGui += OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        float sceneWith = sceneView.position.width;
        float sceneheight = sceneView.position.height;
        // Dibuja la interfaz sobre la cámara de la escena
        Handles.BeginGUI();
        // Dibuja aquí tu interfaz gráfica, por ejemplo:
        Handles.DrawSolidRectangleWithOutline(new Rect(sceneWith-120-10, 120, 120, 300), Color.gray, Color.clear);
        if(GUI.Button(new Rect(sceneWith - 120 ,130, 40, 20), "X"))
        {
            VoxelButonsVar.X = !VoxelButonsVar.X;
        }
        if (GUI.Button(new Rect(sceneWith - 120, 160, 40, 20), "Y"))
        {
            VoxelButonsVar.Y = !VoxelButonsVar.Y;
        }
        if (GUI.Button(new Rect(sceneWith - 120, 190, 40, 20), "Z"))
        {
            VoxelButonsVar.Z = !VoxelButonsVar.Z;
        }

        if (GUI.Button(new Rect(sceneWith - 60, 130, 40, 20), "X1"))
        {
            VoxelButonsVar.X1 = !VoxelButonsVar.X1;
        }
        if (GUI.Button(new Rect(sceneWith - 60, 160, 40, 20), "Y1"))
        {
            VoxelButonsVar.Y1 = !VoxelButonsVar.Y1;
        }
        if (GUI.Button(new Rect(sceneWith - 60, 190, 40, 20), "Z1"))
        {
            VoxelButonsVar.Z1 = !VoxelButonsVar.Z1;
        }

        if (VoxelButonsVar.TogleConstruct)
        {
            if (GUI.Button(new Rect(sceneWith - 120, 230, 100, 20), "Mode:Construct"))
            {
                VoxelButonsVar.TogleConstruct = false;
            }
        }
        else
        {
            if (GUI.Button(new Rect(sceneWith - 120, 230, 100, 20), "Mode:Destroy"))
            {
                VoxelButonsVar.TogleConstruct = true;
            }
        }

        if (GUI.Button(new Rect(sceneWith - 120, 260, 40, 20), "-"))
        {
            VoxelButonsVar.BlockID -= 1;
        }
        GUI.Label(new Rect(sceneWith - 75, 260, 40, 20), VoxelButonsVar.BlockID.ToString());
        if (GUI.Button(new Rect(sceneWith - 60, 260, 40, 20), "+"))
        {
            VoxelButonsVar.BlockID += 1;
        }

        Handles.EndGUI();

    }
}
