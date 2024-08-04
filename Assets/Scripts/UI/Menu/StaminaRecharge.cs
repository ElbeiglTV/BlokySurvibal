using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRecharge : MonoBehaviour
{
    public void Recharge()
    {
        if (Statics.Stamina >= Statics.MaxStamina) return;
        else Statics.Stamina = Statics.MaxStamina;
    }

    public void BrickCharge()
    {
        Statics.currency += 10;
    }

    public void GoldCharge()
    {
        Statics.currency += 100;
    }
}
