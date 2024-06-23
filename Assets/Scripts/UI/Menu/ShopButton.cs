using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] Image _buttonImage;
    [SerializeField] TextMeshProUGUI _upgradePrice, _upgradeName;

    public void SetParams(ButtonSetting settings)
    {
        _buttonImage.sprite = settings.buttonImage;
        _upgradePrice.text = settings.upgradeInitialPrice;
        _upgradeName.text = settings.upgradeName;
    }
}
