using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyUpdater : MonoBehaviour
{
    public TMPro.TMP_Text currencyText, goldText, staminaText;
    private int _previousCurrency, _previousGold, _previousStamina;

    void Start()
    {
        _previousCurrency = Statics.currency;
        _previousGold = Statics.gold;
        _previousStamina = Statics.Stamina;
        currencyText.text = Statics.currency.ToString();
        goldText.text = Statics.gold.ToString();
        staminaText.text = Statics.Stamina.ToString() + "/" + Statics.MaxStamina.ToString();
    }

    void Update()
    {
        if (_previousCurrency != Statics.currency || _previousGold != Statics.gold || _previousStamina != Statics.Stamina)
        {
            UpdateCurrency();
        }
    }

    void UpdateCurrency()
    {
        currencyText.text = Statics.currency.ToString();
        goldText.text = Statics.gold.ToString();
        staminaText.text = Statics.Stamina.ToString() + "/" + Statics.MaxStamina.ToString();
        _previousCurrency = Statics.currency;
        _previousGold = Statics.gold;
        _previousStamina = Statics.Stamina;
    }
}
