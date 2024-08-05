using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Baner", menuName = "NewBaner")]
public class GachaBaner : ScriptableObject
{
    public string banerName;
    public List<GachaItem> items = new List<GachaItem>();
    [Header("Utility Info")]
   public int totalItems;
     public float totalWeigth;

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