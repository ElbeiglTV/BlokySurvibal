using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaguageButton : MonoBehaviour
{
    public SystemLanguage language = default;

    void Start()
    {
        LocalizationManager.instance.OnChangeLanguage += () =>
        {
            if (language == LocalizationManager.instance.language)
            {
                GetComponent<Button>().image.color = Color.green;
            }
            else
            {
                GetComponent<Button>().image.color = Color.red;
            }
        };
    }

    public void ChangeLanguage()
    {
        LocalizationManager.instance.ChangeLeguange(language);
    }
}
