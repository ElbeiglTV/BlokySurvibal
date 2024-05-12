using UnityEngine;

[CreateAssetMenu(fileName = "ResourceManager", menuName = "Custom Tools/Resource Manager", order = 1)]
public class ResourceController : ScriptableObject
{
    [Header("Wood")]
    [Tooltip("Rango minimo de madera que se puede obtener al matar a un enemigo.")]
    public int woodRandomRangeMinAmount;
    [Tooltip("Rango maximo de madera que se puede obtener al matar a un enemigo.")]
    public int woodRandomRangeMaxAmount;

    [Header("Stone")]
    [Tooltip("Rango minimo de piedra que se puede obtener al matar a un enemigo.")]
    public int stoneRandomRangeMinAmount;
    [Tooltip("Rango maximo de piedra que se puede obtener al matar a un enemigo.")]
    public int stoneRandomRangeMaxAmount;

    [Header("Gold")]
    [Tooltip("Rango minimo de oro que se puede obtener al matar a un enemigo.")]
    public int goldRandomRangeMinAmount;
    [Tooltip("Rango maximo de oro que se puede obtener al matar a un enemigo.")]
    public int goldRandomRangeMaxAmount;

    [Header("Bricks")]
    [Tooltip("Rango minimo de ladrillos que se pueden obtener al matar a un enemigo.")]
    public int bricksRandomRangeMinAmount;
    [Tooltip("Rango maximo de ladrillos que se pueden obtener al matar a un enemigo.")]
    public int bricksRandomRangeMaxAmount;
    [Tooltip("Probabilidad de que un enemigo te de ladrillos al morir.")]
    public int bricksProbability;
    [Tooltip("Cantidad de ladrillos que se obtienen al terminar un nivel.")]
    public int bricksPerLevel;
}
