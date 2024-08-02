using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public List<GachaBaner> gachaBaner; // Lista de ítems gacha configurables desde el inspector

    // Método para obtener un ítem al azar basado en la tasa de obtención
    public GachaItem GetRandomItem(GachaBaner baner)
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
                return item;
            }
        }


        return null; // Esto no debería ocurrir si las tasas están bien configuradas
    }
    public GachaItem GetRandomItem(int banerInt)
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
                return item;
            }
        }


        return null; // Esto no debería ocurrir si las tasas están bien configuradas
    }


}
