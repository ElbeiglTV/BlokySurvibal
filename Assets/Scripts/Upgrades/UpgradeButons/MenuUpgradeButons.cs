using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUpgradeButons : MonoBehaviour
{
    public List<float> StaminaUpgradesCost = new List<float>();
    public List<float> HealthUpgradesCost = new List<float>();
    public List<float> DamageUpgradesCost = new List<float>();
     


    public void UpgradeStamina()
    {
        if (StaminaUpgradesCost.Count >= Statics.StaminaUpgradeLevel) return;
        if (Statics.gold >= StaminaUpgradesCost[Statics.StaminaUpgradeLevel])
        {
            Statics.currency -= 10;
            Statics.MaxStamina += 5;
        }
        Statics.StaminaUpgradeLevel++;
        SaveSystem.instance.Save();
    }
    public void UpgradeHealth()
    {
        if (HealthUpgradesCost.Count >= Statics.HealthUpgradeLevel) return;
        if (Statics.gold >= HealthUpgradesCost[Statics.HealthUpgradeLevel])
        {
            Statics.currency -= 10;
            Statics.playerMaxHealth += 10;
        }
        Statics.HealthUpgradeLevel++;
        SaveSystem.instance.Save();
    }
    public void UpgradeDamage()
    {
        if (DamageUpgradesCost.Count >= Statics.DamageUpgradeLevel) return;
        if (Statics.gold >= DamageUpgradesCost[Statics.DamageUpgradeLevel])
        {
            Statics.currency -= 10;
            Statics.playerBaseDamage += 10;
        }
        Statics.DamageUpgradeLevel++;
        SaveSystem.instance.Save();
    }
}
