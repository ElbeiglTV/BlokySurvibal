using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public List<GachaBaner> gachaBaner; // Lista de �tems gacha configurables desde el inspector

    // M�todo para obtener un �tem al azar basado en la tasa de obtenci�n
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
                }
                else
                {
                    Statics.GachaInventory.Add(item.itemID, 1);
                }
            }
        }


         // Esto no deber�a ocurrir si las tasas est�n bien configuradas
    }
    public void GetRandomItem(int banerInt)
    {
        float totalDropRate = 0f;


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
                }
                else
                {
                    Statics.GachaInventory.Add(item.itemID, 1);
                }
            }
        }

    }


}
