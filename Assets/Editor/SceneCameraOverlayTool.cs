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
        // Dibuja la interfaz sobre la c�mara de la escena
        Handles.BeginGUI();
        // Dibuja aqu� tu interfaz gr�fica, por ejemplo:

        #region UiBox
        Handles.DrawSolidRectangleWithOutline(new Rect(sceneWith - 110 - 10, 120, 100, 300), Color.gray, Color.clear);
        Handles.DrawSolidRectangleWithOutline(new Rect(sceneWith - 120 - 10, 130, 120, 280), Color.gray, Color.clear);
        Handles.color = Color.gray;
        Handles.DrawSolidDisc(new Vector3(sceneWith - 110 - 10, 130, 0), Vector3.forward, 10);
        Handles.DrawSolidDisc(new Vector3(sceneWith - 20, 130, 0), Vector3.forward, 10);
        Handles.DrawSolidDisc(new Vector3(sceneWith - 110 - 10, 410, 0), Vector3.forward, 10);
        Handles.DrawSolidDisc(new Vector3(sceneWith - 20, 410, 0), Vector3.forward, 10);
        #endregion








        if (GUI.Button(new Rect(sceneWith - 120, 130, 40, 20), "X"))
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
        else if (!VoxelButonsVar.TogleConstruct && VoxelButonsVar.BlockID != 0)
        {
            if (GUI.Button(new Rect(sceneWith - 120, 230, 100, 20), "Mode:Remplase"))
            {
                VoxelButonsVar.BlockID = 0;
            }
        }
        else
        {
            if (GUI.Button(new Rect(sceneWith - 120, 230, 100, 20), "Mode:Destroy"))
            {
                VoxelButonsVar.TogleConstruct = true;
                VoxelButonsVar.BlockID = VoxelButonsVar.BlockID != 0 ? VoxelButonsVar.BlockID : (byte)1;
            }
        }
        if (VoxelButonsVar.BlockID != 0)
        {
            if (GUI.Button(new Rect(sceneWith - 120, 260, 40, 20), "-"))
            {
                VoxelButonsVar.BlockID -= VoxelButonsVar.BlockID != (byte)1 ? (byte)1 : (byte)0;
            }
            GUI.Label(new Rect(sceneWith - 75, 260, 40, 20), VoxelButonsVar.BlockID.ToString());
            if (GUI.Button(new Rect(sceneWith - 60, 260, 40, 20), "+"))
            {
                VoxelButonsVar.BlockID += 1;
            }
        }
        DrawTexture(VoxelButonsVar.BlockID, sceneWith);





        Handles.EndGUI();

    }
    static void DrawTexture(byte textId, float sceneWith)
    {
        if (textId == 1) GUI.DrawTexture(new Rect(sceneWith - 120, 300, 100, 100), Resources.Load<Texture2D>("1"));
        else if (textId == 2) GUI.DrawTexture(new Rect(sceneWith - 120, 300, 100, 100), Resources.Load<Texture2D>("2"));
        else if (textId == 3) GUI.DrawTexture(new Rect(sceneWith - 120, 300, 100, 100), Resources.Load<Texture2D>("3"));
        else if (textId == 4) GUI.DrawTexture(new Rect(sceneWith - 120, 300, 100, 100), Resources.Load<Texture2D>("4"));
        else if (textId == 5) GUI.DrawTexture(new Rect(sceneWith - 120, 300, 100, 100), Resources.Load<Texture2D>("5"));
        else if (textId == 6) GUI.DrawTexture(new Rect(sceneWith - 120, 300, 100, 100), Resources.Load<Texture2D>("6"));

    }
}
