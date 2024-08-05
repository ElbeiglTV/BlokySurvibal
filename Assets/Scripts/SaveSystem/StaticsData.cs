using UnityEngine;
[System.Serializable]
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
            maxStamina = Statics.MaxStamina;
            firstTime = Statics.FirstTime;
            staminaUpgradeLevel = Statics.StaminaUpgradeLevel;
            healthUpgradeLevel = Statics.HealthUpgradeLevel;
            damageUpgradeLevel = Statics.DamageUpgradeLevel;
            playerMaxHealth = Statics.playerMaxHealth;
            playerBaseDamage = Statics.playerBaseDamage;
            GachaInventory = Statics.GachaInventory;
            currentSkin = Statics.currentSkin;

        }
        else
        {
            wood = 0;
            stone = 0;
            gold = 0;
            currency = 0;
            stamina = 0;
            maxStamina = 20;
            firstTime = true;
            staminaUpgradeLevel = 0;
            healthUpgradeLevel = 0;
            damageUpgradeLevel = 0;
            playerMaxHealth = 100;
            playerBaseDamage = 0;
            GachaInventory = new SerialisedDictionary<int, int>();
            currentSkin = Skin.Standard;
        }
    }
    public void ActualizeStatics()
    {
        Statics.wood = wood;
        Statics.stone = stone;
        Statics.gold = gold;
        Statics.currency = currency;
        Statics.Stamina = stamina;
        Statics.MaxStamina = maxStamina;
        Statics.FirstTime = firstTime;
        Statics.StaminaUpgradeLevel = staminaUpgradeLevel;
        Statics.HealthUpgradeLevel = healthUpgradeLevel;
        Statics.DamageUpgradeLevel = damageUpgradeLevel;
        Statics.playerMaxHealth = playerMaxHealth;
        Statics.playerBaseDamage = playerBaseDamage;
        Statics.GachaInventory = GachaInventory;
        Statics.currentSkin = currentSkin;

    }


    public int wood = default;
    public int stone = default;
    public int gold = default;
    public int currency = default;
    public int stamina = default;
    public int maxStamina = 0;
    public bool firstTime = true;
    public int staminaUpgradeLevel = 0;
    public int healthUpgradeLevel = 0;
    public int damageUpgradeLevel = 0;
    public float playerMaxHealth = 100;
    public int playerBaseDamage = 0;
    public SerialisedDictionary<int, int> GachaInventory = new SerialisedDictionary<int, int>();
    public Skin currentSkin = Skin.Standard;
}
