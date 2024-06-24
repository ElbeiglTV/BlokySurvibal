using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCreator : MonoBehaviour
{
    [SerializeField] ShopButton _button;
    [SerializeField] Transform _buttonParent;
    [SerializeField] ShopButtonScriptable _buttonSettings;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        if (_buttonSettings == null) _buttonSettings = Resources.Load<ShopButtonScriptable>("ButtonShopManager");

        foreach (var buttonSetting in _buttonSettings.buttonSettings)
        {
            var button = Instantiate(_button, _buttonParent);
            button.SetParams(buttonSetting);
            if (buttonSetting.upgradeName == "Mejorar vida")
            {
                button.GetComponentInChildren<Button>().onClick.AddListener(() => MenuUpgradeButons.instance.UpgradeHealth());
            }
            else if (buttonSetting.upgradeName == "Mejorar daño")
            {
                button.GetComponentInChildren<Button>().onClick.AddListener(() => MenuUpgradeButons.instance.UpgradeDamage());
            }
            else if (buttonSetting.upgradeName == "Mejorar estamina")
            {
                button.GetComponentInChildren<Button>().onClick.AddListener(() => MenuUpgradeButons.instance.UpgradeStamina());
            }
        }
    }
}
