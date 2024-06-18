using UnityEngine;
using UnityEngine.UI;

public class LevelButtonColorChanger : MonoBehaviour
{
    public Color BlockedColor, CurrentColor, CompletedColor;
    public Button button;

    public void ChangeColor(Color colorToSet)
    {
        button.GetComponent<Image>().color = colorToSet;
    }
}
