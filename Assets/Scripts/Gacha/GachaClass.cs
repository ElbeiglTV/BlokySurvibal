using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GachaItem
{
    [Header("Funtional Data")]
    public GameObject Item;
    [Min(1)] public int dropWeigth;
    public int itemID;


    [Header("Cosmetic Data (Optional)")]

    [Tooltip("Nombre de el item (se mostrara en la UI)")] public string itemName;
    [Tooltip("Rareza de el item (se mostrara en la UI y posiblemente tendra interacciones con algun shader)")] public Rarity rarity;
    [Tooltip("Icono de el item (se mostrara en la UI)")] public Sprite icon;

    [Header("ItemInfo")]
    [InspectorReadOnly] public float Porcentage;
}

[CreateAssetMenu(fileName = "Baner", menuName = "NewBaner")]
public class GachaBaner : ScriptableObject
{
    public string banerName;
    public List<GachaItem> items = new List<GachaItem>();
    [Header("Utility Info")]
    [InspectorReadOnly] public int totalItems;
    [InspectorReadOnly] public float totalWeigth;

    private void OnValidate()
    {
        GetItemProbabilities();
    }
    [ContextMenu("Recalculate Probablility")]
    public void GetItemProbabilities()
    {
        float totalDropRate = 0f;
        foreach (var item in items)
        {
            if (item.dropWeigth < 1)
            {
                item.dropWeigth = 1;
            }
            totalDropRate += item.dropWeigth;
        }
        foreach (var item in items)
        {
            item.Porcentage = (item.dropWeigth / totalDropRate) * 100f; // Probabilidad en porcentaje
        }
        totalItems = items.Count;
        totalWeigth = totalDropRate;
    }
}
public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
