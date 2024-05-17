/*using UnityEngine;
using System.Collections.Generic;
using Unity.Services.RemoteConfig;

public class RemoteConfigManager : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }
    private void Awake()
    {
        RemoteConfigService.Instance.FetchCompleted += ApplyRemoteConfig;
         RemoteConfigService.Instance.FetchConfigs<userAttributes,appAttributes>(new userAttributes(),new appAttributes());
    }

    private void ApplyRemoteConfig(ConfigResponse response)
    {
        if (response.status == ConfigRequestStatus.Success)
        {
            List<object> staminaUpgradesCostList = Unity.RemoteConfig.ConfigManager.appConfig.GetList("StaminaUpgradesCost");
            List<object> healthUpgradesCostList = Unity.RemoteConfig.ConfigManager.appConfig.GetList("HealthUpgradesCost");
            List<object> damageUpgradesCostList = Unity.RemoteConfig.ConfigManager.appConfig.GetList("DamageUpgradesCost");

            List<float> staminaUpgradesCost = ConvertList<float>(staminaUpgradesCostList);
            List<float> healthUpgradesCost = ConvertList<float>(healthUpgradesCostList);
            List<float> damageUpgradesCost = ConvertList<float>(damageUpgradesCostList);

            Debug.Log("Stamina Upgrades Cost: " + string.Join(", ", staminaUpgradesCost));
            Debug.Log("Health Upgrades Cost: " + string.Join(", ", healthUpgradesCost));
            Debug.Log("Damage Upgrades Cost: " + string.Join(", ", damageUpgradesCost));
        }
        else
        {
            Debug.LogError("Error al obtener datos de Remote Config: " + response.error);
        }
    }

    private List<T> ConvertList<T>(List<object> list)
    {
        List<T> convertedList = new List<T>();
        foreach (var item in list)
        {
            convertedList.Add((T)item);
        }
        return convertedList;
    }
}*/
