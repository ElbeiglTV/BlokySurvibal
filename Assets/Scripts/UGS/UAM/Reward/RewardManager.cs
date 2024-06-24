using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    public Button staminaRewardButton;
    public Button BrickRewardButton;
    public Button GoldRewardButton;


    private void Update()
    {
        if (PlayerPrefs.HasKey("StaminaRewardTime"))
        {
            DateTime dateTime = DateTime.Parse(PlayerPrefs.GetString("StaminaRewardTime"));
            TimeSpan timeSpan = DateTime.Now - dateTime;
            if (timeSpan.Seconds >= 10)
            {
                staminaRewardButton.interactable = true;
                PlayerPrefs.DeleteKey("StaminaRewardTime");
            }
        }
        if (PlayerPrefs.HasKey("BrickRewardTime"))
        {
            DateTime dateTime = DateTime.Parse(PlayerPrefs.GetString("BrickRewardTime"));
            TimeSpan timeSpan = DateTime.Now - dateTime;
            if (timeSpan.Seconds >= 10)
            {
                staminaRewardButton.interactable = true;
                PlayerPrefs.DeleteKey("BrickRewardTime");
            }
        }
        if (PlayerPrefs.HasKey("GoldRewardTime"))
        {
            DateTime dateTime = DateTime.Parse(PlayerPrefs.GetString("GoldRewardTime"));
            TimeSpan timeSpan = DateTime.Now - dateTime;
            if (timeSpan.Seconds >= 10)
            {
                staminaRewardButton.interactable = true;
                PlayerPrefs.DeleteKey("GoldRewardTime");
            }
        }
    }

    public void StaminaButton()
    {
        AdManager.instance.RewardAction = StaminaReward;
        AdManager.instance.SkipedRewardAction = SkipedStaminaReward;
        AdManager.instance.ShowAdd();

    }

    public void BrickButton()
    {
        AdManager.instance.RewardAction = BrickReward;
        AdManager.instance.SkipedRewardAction = SkipedBrickReward;
        AdManager.instance.ShowAdd();

    }
    public void GoldButton()
    {
        AdManager.instance.RewardAction = GoldReward;
        AdManager.instance.SkipedRewardAction = SkipedGoldReward;
        AdManager.instance.ShowAdd();

    }









    public void StaminaReward()
    {
        Statics.Stamina += 2;
        staminaRewardButton.interactable = false;
        AdManager.instance.RewardAction = null;
        DateTime dateTime = DateTime.Now;
#if UNITY_ANDROID
        NotificationManager.instance.CrearNotificacion(dateTime.AddSeconds(10));
#endif
        PlayerPrefs.SetString("StaminaRewardTime", dateTime.ToString());


    }
    public void SkipedStaminaReward()
    {
        Statics.Stamina += 1;
        staminaRewardButton.interactable = false;
        AdManager.instance.RewardAction = null;
        DateTime dateTime = DateTime.Now;
#if UNITY_ANDROID
        NotificationManager.instance.CrearNotificacion(dateTime.AddSeconds(10));
#endif
        PlayerPrefs.SetString("StaminaRewardTime", dateTime.ToString());


    }
    public void BrickReward()
    {
        Statics.currency += 10;
        staminaRewardButton.interactable = false;
        AdManager.instance.RewardAction = null;
        DateTime dateTime = DateTime.Now;
#if UNITY_ANDROID
        NotificationManager.instance.CrearNotificacion(dateTime.AddSeconds(10));
#endif
        PlayerPrefs.SetString("BrickRewardTime", dateTime.ToString());


    }
    public void SkipedBrickReward()
    {
        Statics.currency += 5;
        staminaRewardButton.interactable = false;
        AdManager.instance.RewardAction = null;
        DateTime dateTime = DateTime.Now;
#if UNITY_ANDROID
        NotificationManager.instance.CrearNotificacion(dateTime.AddSeconds(10));
#endif
        PlayerPrefs.SetString("BrickRewardTime", dateTime.ToString());


    }
    public void GoldReward()
    {
        Statics.gold += 100;
        staminaRewardButton.interactable = false;
        AdManager.instance.RewardAction = null;
        DateTime dateTime = DateTime.Now;
#if UNITY_ANDROID
        NotificationManager.instance.CrearNotificacion(dateTime.AddSeconds(10));
#endif
        PlayerPrefs.SetString("GoldRewardTime", dateTime.ToString());


    }
    public void SkipedGoldReward()
    {
        Statics.gold += 50;
        staminaRewardButton.interactable = false;
        AdManager.instance.RewardAction = null;
        DateTime dateTime = DateTime.Now;
#if UNITY_ANDROID
        NotificationManager.instance.CrearNotificacion(dateTime.AddSeconds(10));
#endif
        PlayerPrefs.SetString("GoldRewardTime", dateTime.ToString());


    }








}
