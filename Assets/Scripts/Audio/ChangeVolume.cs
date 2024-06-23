using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public AudioMixer Master;
    public Button musicButton, sfxButton;
    private float currentMusicVolume = 1f, currentSFXVolume = 1f;

    public void MusicButton()
    {
        if (currentMusicVolume == 1f)
        {
            currentMusicVolume = 0.0001f;
            Mute(currentMusicVolume, "MusicVolume");
            musicButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            currentMusicVolume = 1f;
            Unmute(currentMusicVolume, "MusicVolume");
            musicButton.GetComponent<Image>().color = Color.green;
        }
    }

    public void SFXButton()
    {
        if (currentSFXVolume == 1f)
        {
            currentSFXVolume = 0.0001f;
            Mute(currentSFXVolume, "SFXVolume");
            sfxButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            currentSFXVolume = 1f;
            Unmute(currentSFXVolume, "SFXVolume");
            sfxButton.GetComponent<Image>().color = Color.green;
        }
    }

    void Mute(float volume, string parameter)
    {
        Master.SetFloat(parameter, Mathf.Log10(volume) * 20);
    }

    void Unmute(float volume, string parameter)
    {
        Master.SetFloat(parameter, Mathf.Log10(volume) * 20);
    }
}
