using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Statics
{
    public static int wood = default;
    public static int stone = default;
    public static int gold = default;
    public static int currency = default;
    public static int Stamina = default;
    public static int MaxStamina = 20;

    #region UserVars
    public static bool FirstTime = true;
    #endregion
    #region UpgradeProgressionVars
    public static int StaminaUpgradeLevel = 0;
    public static int HealthUpgradeLevel = 0;
    public static int DamageUpgradeLevel = 0;
    #endregion



    #region PlayerUpgradeableVars
    public static float playerMaxHealth = 100;
    public static int playerBaseDamage;

    #endregion

    public static void Reset()
    {
        wood = 0;
        stone = 0;
        gold = 0;
        currency = 0;
        Stamina = 0;
        FirstTime = true;
        StaminaUpgradeLevel = 0;
        HealthUpgradeLevel = 0;
        DamageUpgradeLevel = 0;
        playerMaxHealth = 100;
        playerBaseDamage = 0;

    }
}
