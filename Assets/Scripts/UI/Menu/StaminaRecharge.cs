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

    public void BrickCharge(int value)
    {
        Statics.currency += value;
    }

    public void GoldCharge(int value)
    {
        Statics.currency += value;
    }
}
