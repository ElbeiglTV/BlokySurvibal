using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCreator : MonoBehaviour
{
    [SerializeField] ShopButton _button;
    [SerializeField] Transform _buttonParent;
    [SerializeField] ShopButtonScriptable _buttonSettings;

    void Start()
    {
        if (_buttonSettings == null) _buttonSettings = Resources.Load<ShopButtonScriptable>("ButtonShopManager");

        foreach (var buttonSetting in _buttonSettings.buttonSettings)
        {
            var button = Instantiate(_button, _buttonParent);
            button.SetParams(buttonSetting);
        }
    }
}
