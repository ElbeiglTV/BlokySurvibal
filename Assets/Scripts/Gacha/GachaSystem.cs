using UnityEngine;
using System.Collections.Generic;

public class GachaSystem : MonoBehaviour
{
    public List<GachaItem> gachaItems; // Lista de �tems gacha configurables desde el inspector

    // M�todo para obtener un �tem al azar basado en la tasa de obtenci�n
    public GachaItem GetRandomItem()
    {
        float totalDropRate = 0f;
        foreach (var item in gachaItems)
        {
            totalDropRate += item.dropWeigth;
        }

        float randomValue = Random.value * totalDropRate;
        float cumulativeDropRate = 0f;

        foreach (var item in gachaItems)
        {
            cumulativeDropRate += item.dropWeigth;
            if (randomValue < cumulativeDropRate)
            {
                return item;
            }
        }

        return null; // Esto no deber�a ocurrir si las tasas est�n bien configuradas
    }

    private void OnValidate()
    {
        GetItemProbabilities();
    }
    // M�todo para calcular las probabilidades de cada �tem
    [ContextMenu("Recalculate Probablility")]
    public void GetItemProbabilities()
    {
        float totalDropRate = 0f;
        foreach (var item in gachaItems)
        {
            totalDropRate += item.dropWeigth;
        }

        
        foreach (var item in gachaItems)
        {
            item.dropPorcentage = (item.dropWeigth / totalDropRate) * 100f; // Probabilidad en porcentaje
        }

        
    }
}
