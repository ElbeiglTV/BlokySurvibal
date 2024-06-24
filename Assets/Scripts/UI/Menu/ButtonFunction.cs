using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    private void Update()
    {
        var allKids = GetComponentsInChildren<TextMeshProUGUI>();
        var kid = allKids.Where(k => k.gameObject.name == "UpgradeName").FirstOrDefault();
        if (kid.text.Contains("vida"))
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => MenuUpgradeButons.instance.UpgradeHealth());
        }
        else if (kid.text.Contains("daño"))
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => MenuUpgradeButons.instance.UpgradeDamage());
        }
        else if (kid.text.Contains("estamina"))
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => MenuUpgradeButons.instance.UpgradeStamina());
        }
    }
}
