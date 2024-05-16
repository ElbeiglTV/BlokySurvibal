using UnityEngine;
using UnityEditor;

public class FlyWeightEditor : EditorWindow
{
    // Referencia estática a la clase que contiene las variables que deseas modificar
    private AgentFlyWeight agentFlyWeight;

    [MenuItem("Window/Static Variables Editor")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(FlyWeightEditor));
    }

    private void OnGUI()
    {
        GUILayout.Label("Static Variables Editor", EditorStyles.boldLabel);

        // Busca la referencia estática a tu clase
        agentFlyWeight = FlyWeightPointer.agentFlyWeight;

        if (agentFlyWeight != null)
        {
            // Muestra y edita las variables
            agentFlyWeight.maxSpeed = EditorGUILayout.FloatField("MaxSpeed", agentFlyWeight.maxSpeed);
            agentFlyWeight.maxForce = EditorGUILayout.Slider("MaxForce",agentFlyWeight.maxForce,0,0.15f);
            agentFlyWeight.radius = EditorGUILayout.FloatField("Radius", agentFlyWeight.radius);
            agentFlyWeight.maxDistance = EditorGUILayout.FloatField("MaxDistance", agentFlyWeight.maxDistance);
            agentFlyWeight.visionDistance = EditorGUILayout.FloatField("VicionDistance", agentFlyWeight.visionDistance);
            
 

    
            
        }
        else
        {
            GUILayout.Label("Static reference not found!", EditorStyles.boldLabel);
        }
    }
}
