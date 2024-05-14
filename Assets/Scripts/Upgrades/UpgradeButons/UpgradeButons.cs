using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButons : MonoBehaviour
{
    int UpgradeIndex;
    public List<GameObject> UpgradeList;
    public int BaseWoodUpgradeCost;
    public int BaseStoneUpgradeCost;

    public event Action OnFinishUpgrade;

    public void UpgradeBase()
    {
        if (Statics.wood >= BaseWoodUpgradeCost && Statics.stone >= BaseStoneUpgradeCost)
        {
            UpgradeIndex++;
            foreach (GameObject Upgrade in UpgradeList) Upgrade.SetActive(false);
            UpgradeList[UpgradeIndex].SetActive(true);
            ResourcesManager.instance.wood = -BaseWoodUpgradeCost;
            ResourcesManager.instance.stone = -BaseStoneUpgradeCost;
        }
        if (UpgradeIndex >= UpgradeList.Count - 1) OnFinishUpgrade?.Invoke();
    }

}
