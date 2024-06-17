using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ButtonShopManager", menuName = "Custom Tools/Button Shop Manager", order = 2)]

public class ShopButtonScriptable : ScriptableObject
{
    public List<ButtonSetting> buttonSettings = new List<ButtonSetting>();
}

[System.Serializable]
public class ButtonSetting
{
    public Sprite buttonImage;
    public string upgradeInitialPrice, upgradeName;
}