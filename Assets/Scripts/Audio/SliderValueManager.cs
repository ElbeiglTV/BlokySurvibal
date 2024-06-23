using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueManager : MonoBehaviour
{
    // Este script se aplica en los sliders de volumen
    private Slider slider;
    public SliderType sliderName;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        if (slider != null)
        {
            switch (sliderName)
            {
                case SliderType.Master:
                    MasterSliderValue();
                    break;
                case SliderType.Music:
                    MusicSliderValue();
                    break;
                case SliderType.SFX:
                    SFXSliderValue();
                    break;
            }
        }
    }
    //setea el valor del slider
    public void MasterSliderValue()
    {
        slider.SetValueWithoutNotify(AudioVolumeManager.MasterVolume);
    }
    public void MusicSliderValue()
    {
        slider.SetValueWithoutNotify(AudioVolumeManager.MusicVolume);
    }
    public void SFXSliderValue()
    {
        slider.SetValueWithoutNotify(AudioVolumeManager.SFXVolume);
    }
}
public enum SliderType {Master, Music, SFX }

