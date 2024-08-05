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


public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
