using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdManager instance;

    public Action RewardAction;
    public Action SkipedRewardAction;

    public string androidGameId = "5643162";
    public string androidAddId= "Rewarded_Android";
    string selectedId;
    string selectedAddId;
    public bool testMode = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            InitializeAdd();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void InitializeAdd()
    {
#if UNITY_ANDROID
        selectedId = androidGameId;
        selectedAddId = androidAddId;
#elif UNITY_EDITOR && UNITY_ANDROID || UNITY_EDITOR || UNITY_ANDROID
        selectedId = androidGameId;
        selectedAddId = androidAddId;
#endif
        if (!Advertisement.isInitialized)
        {
            Advertisement.Initialize(selectedId, testMode, this); // initialize the ads
        }



    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Unity Ads Failed to Load: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
       
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if(placementId.Equals(selectedAddId)&& showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            //recompensa
            RewardAction?.Invoke();
        }
        else if(placementId.Equals(selectedAddId) && showCompletionState.Equals(UnityAdsShowCompletionState.SKIPPED))
        {
            //recompensa para anuncio saltado
            SkipedRewardAction?.Invoke();
        }
    }
    [ContextMenu("ShowAdd")]
    public void ShowAdd()
    {
        Advertisement.Load(selectedAddId, this);
    }
}
