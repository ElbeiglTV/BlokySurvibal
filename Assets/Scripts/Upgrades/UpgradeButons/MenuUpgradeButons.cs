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
            Statics.currency -= menuUpgradeCost.StaminaUpgradesCost[Statics.StaminaUpgradeLevel];
            Statics.MaxStamina += 5*Statics.StaminaUpgradeLevel;
        }
        Statics.StaminaUpgradeLevel++;
        SaveSystem.instance.Save();
    }
    public void UpgradeHealth()
    {
        if (menuUpgradeCost.HealthUpgradesCost.Count >= Statics.HealthUpgradeLevel) return;
        if (Statics.gold >= menuUpgradeCost.HealthUpgradesCost[Statics.HealthUpgradeLevel])
        {
            Statics.currency -= menuUpgradeCost.HealthUpgradesCost[Statics.HealthUpgradeLevel];
            Statics.playerMaxHealth += 10*Statics.HealthUpgradeLevel;
        }
        Statics.HealthUpgradeLevel++;
        SaveSystem.instance.Save();
    }
    public void UpgradeDamage()
    {
        if (menuUpgradeCost.DamageUpgradesCost.Count >= Statics.DamageUpgradeLevel) return;
        if (Statics.gold >= menuUpgradeCost.DamageUpgradesCost[Statics.DamageUpgradeLevel])
        {
            Statics.currency -= menuUpgradeCost.DamageUpgradesCost[Statics.DamageUpgradeLevel];
            Statics.playerBaseDamage += 10* Statics.DamageUpgradeLevel/2;
        }
        Statics.DamageUpgradeLevel++;
        SaveSystem.instance.Save();
    }
}
[System.Serializable]
public class MenuUpgradeCost
{
    public List<int> StaminaUpgradesCost = new List<int>();
    public List<int> HealthUpgradesCost = new List<int>();
    public List<int> DamageUpgradesCost = new List<int>();
}
