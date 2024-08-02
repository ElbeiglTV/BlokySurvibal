using UnityEngine;
using System.Collections.Generic;

public class GachaSystem : MonoBehaviour
{
    public List<GachaItem> gachaItems; // Lista de ítems gacha configurables desde el inspector

    // Método para obtener un ítem al azar basado en la tasa de obtención
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

        return null; // Esto no debería ocurrir si las tasas están bien configuradas
    }

    private void OnValidate()
    {
        GetItemProbabilities();
    }
    // Método para calcular las probabilidades de cada ítem
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
