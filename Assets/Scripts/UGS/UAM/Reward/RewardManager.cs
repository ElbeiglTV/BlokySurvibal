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
    }





    public void BrickReward()
    {

    }
    public void StaminaButton()
    {
        AdManager.instance.RewardAction = StaminaReward;
        AdManager.instance.ShowAdd();
    }
    public void StaminaReward()
    {
        Statics.Stamina += 1;
        staminaRewardButton.interactable = false;
        AdManager.instance.RewardAction = null;
        DateTime dateTime = DateTime.Now;
        PlayerPrefs.SetString("StaminaRewardTime", dateTime.ToString());

    }








}
