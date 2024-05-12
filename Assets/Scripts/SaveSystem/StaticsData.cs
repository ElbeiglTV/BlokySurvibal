using UnityEngine;

public class StaticsData
{
    public StaticsData(bool CatchData)
    {
        if(CatchData)
        {
            wood = Statics.wood;
            stone = Statics.stone;
            gold = Statics.gold;
            currency = Statics.currency;
            stamina = Statics.Stamina;
            
        }
        else
        {
            wood = 0;
            stone = 0;
            gold = 0;
            currency = 0;
            stamina = 0;
        }
    }
    public void ActualizeStatics()
    {
        Statics.wood = wood;
        Statics.stone = stone;
        Statics.gold = gold;
        Statics.currency = currency;
        Statics.Stamina = stamina;
    }


    public int wood = default;
    public int stone = default;
    public int gold = default;
    public int currency = default;
    public int stamina = default;
}
