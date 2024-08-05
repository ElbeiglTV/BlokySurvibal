using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public List<GachaBaner> gachaBaner; // Lista de ítems gacha configurables desde el inspector

    // Método para obtener un ítem al azar basado en la tasa de obtención
    public void GetRandomItem(GachaBaner baner)
    {
        float totalDropRate = 0f;
        foreach (var item in baner.items)
        {
            totalDropRate += item.dropWeigth;
        }
        float randomValue = Random.value * totalDropRate;
        float cumulativeDropRate = 0f;
        foreach (var item in baner.items)
        {
            cumulativeDropRate += item.dropWeigth;
            if (randomValue < cumulativeDropRate)
            {
                if (Statics.GachaInventory.ContainsKey(item.itemID))
                {
                    Statics.GachaInventory.Set(item.itemID, Statics.GachaInventory.Get(item.itemID) + 1);
                    Debug.Log("Has obtenido "+item.itemName+" (" + item.rarity + ")"+" (Item duplicado)");
                    break;
                }
                else
                {
                    Statics.GachaInventory.Add(item.itemID, 1);
                    Debug.Log("Has obtenido " + item.itemName + " ("+item.rarity+")");
                    break;
                }
            }
        }


        // Esto no debería ocurrir si las tasas están bien configuradas
    }
    public void GetRandomItem(int banerInt)
    {
        float totalDropRate = 0f;

        if (banerInt >= gachaBaner.Count)
        {
            Debug.LogError("Baner no encontrado");
            return;
        }

        foreach (var item in gachaBaner[banerInt].items)
        {
            totalDropRate += item.dropWeigth;
        }

        float randomValue = Random.value * totalDropRate;
        float cumulativeDropRate = 0f;
        foreach (var item in gachaBaner[banerInt].items)
        {
            cumulativeDropRate += item.dropWeigth;
            if (randomValue < cumulativeDropRate)
            {
                if (Statics.GachaInventory.ContainsKey(item.itemID))
                {
                    Statics.GachaInventory.Set(item.itemID, Statics.GachaInventory.Get(item.itemID) + 1);
                    break;
                }
                else
                {
                    Statics.GachaInventory.Add(item.itemID, 1);
                    break;
                }
            }
        }

    }


}
