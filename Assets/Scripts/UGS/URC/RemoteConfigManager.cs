using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.RemoteConfig;
using UnityEngine;

public class RemoteConfigManager : MonoBehaviour
{
    [SerializeField]MenuUpgradeButons menuUpgradeButons;
    // Estructuras para los usuarios y las reglas
    struct userAttributes { }
    struct appAttributes { }

    async void Start()
    {
        try
        {
            // Inicializa los servicios de Unity
            await UnityServices.InitializeAsync();

            // Inicia sesi�n de manera an�nima
            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("Signed in anonymously.");
            }

            // Registra el evento para cuando se complete la obtenci�n de la configuraci�n
            RemoteConfigService.Instance.FetchCompleted += ApplyRemoteSettings;

            // Obt�n las configuraciones remotas
            RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());
        }
        catch (Exception e)
        {
            Debug.LogError($"Error during initialization: {e.Message}");
        }
    }

    // M�todo para aplicar los ajustes remotos una vez obtenidos
    void ApplyRemoteSettings(ConfigResponse configResponse)
    {
        // Verifica el origen de los datos
        if (configResponse.requestOrigin == ConfigOrigin.Default ||
            configResponse.requestOrigin == ConfigOrigin.Cached ||
            configResponse.requestOrigin == ConfigOrigin.Remote)
        {
            // Obt�n el JSON de Remote Config
            string jsonArray = RemoteConfigService.Instance.appConfig.GetJson("Menu Upgrade Cost");
            menuUpgradeButons.menuUpgradeCost = JsonConvert.DeserializeObject<MenuUpgradeCost>(jsonArray);

            Debug.Log(jsonArray);
            
        }
    }
}
