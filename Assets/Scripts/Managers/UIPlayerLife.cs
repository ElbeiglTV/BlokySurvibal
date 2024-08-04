using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIPlayerLife : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _playerLifeAmount;
    [SerializeField] Image _playerLifeBar;
    [SerializeField] LifeManager _lifeManager;

    void Update()
    {
        _playerLifeAmount.text = _lifeManager.myLife.ToString();
        _playerLifeBar.fillAmount = _lifeManager.myLife / Statics.playerMaxHealth;
    }
}
