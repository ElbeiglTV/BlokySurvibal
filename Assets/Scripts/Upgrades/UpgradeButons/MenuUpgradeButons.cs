using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MenuUpgradeButons : MonoBehaviour
{
    public MenuUpgradeCost menuUpgradeCost;

    public void UpgradeStamina()
    {
        if (menuUpgradeCost.StaminaUpgradesCost.Count >= Statics.StaminaUpgradeLevel) return;
        if (Statics.gold >= menuUpgradeCost.StaminaUpgradesCost[Statics.StaminaUpgradeLevel])
        {
            Statics.currency -= 10;
            Statics.MaxStamina += 5;
        }
        Statics.StaminaUpgradeLevel++;
        SaveSystem.instance.Save();
    }
    public void UpgradeHealth()
    {
        if (menuUpgradeCost.HealthUpgradesCost.Count >= Statics.HealthUpgradeLevel) return;
        if (Statics.gold >= menuUpgradeCost.HealthUpgradesCost[Statics.HealthUpgradeLevel])
        {
            Statics.currency -= 10;
            Statics.playerMaxHealth += 10;
        }
        Statics.HealthUpgradeLevel++;
        SaveSystem.instance.Save();
    }
    public void UpgradeDamage()
    {
        if (menuUpgradeCost.DamageUpgradesCost.Count >= Statics.DamageUpgradeLevel) return;
        if (Statics.gold >= menuUpgradeCost.DamageUpgradesCost[Statics.DamageUpgradeLevel])
        {
            Statics.currency -= 10;
            Statics.playerBaseDamage += 10;
        }
        Statics.DamageUpgradeLevel++;
        SaveSystem.instance.Save();
    }
}
[System.Serializable]
public class MenuUpgradeCost
{
    public List<float> StaminaUpgradesCost = new List<float>();
    public List<float> HealthUpgradesCost = new List<float>();
    public List<float> DamageUpgradesCost = new List<float>();
}
