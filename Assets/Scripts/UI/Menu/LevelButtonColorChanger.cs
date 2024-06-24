using UnityEngine;
using UnityEngine.UI;

public class LevelButtonColorChanger : MonoBehaviour
{
    public Color BlockedColor, CurrentColor, CompletedColor;
    public Button buttonlevl1;
    public Button buttonlevl2;


    private void Update()
    {
        
        if (PlayerPrefs.HasKey("Level1")&&PlayerPrefs.GetInt("Level1") == 1)
        {
            ChangeColor(buttonlevl1, CompletedColor);
            ChangeColor(buttonlevl2, CurrentColor);
            buttonlevl2.interactable = true;
        }
        else
        {
            ChangeColor(buttonlevl1, CurrentColor);
        }

        if (PlayerPrefs.HasKey("Level2") && PlayerPrefs.GetInt("Level2") == 1)
        {
            ChangeColor(buttonlevl2, CompletedColor);
        }
        else
        {
            ChangeColor(buttonlevl2, CurrentColor);
        }
    }





    public void ChangeColor(Button button ,Color colorToSet)
    {
        button.GetComponent<Image>().color = colorToSet;
    }
}
