using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//TPFinal - Matias Labreniuk
public class AudioVolumeManager : MonoBehaviour
{
    //Este script se pone en un objeto en escena y desde prefab en los sliders
    public static AudioVolumeManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("Audio")]
    [SerializeField] private AudioMixer _mixer;

    [Header("UI")]
    [Range(.0001f, 1f)][SerializeField] static float _masterVolume = 1f;
    [Range(.0001f, 1f)][SerializeField] static float _musicVolume = 1f;
    [Range(.0001f, 1f)][SerializeField] static float _sfxVolume = 1f;

    public static float MasterVolume { get { return _masterVolume; } }
    public static float MusicVolume { get { return _musicVolume; } }
    public static float SFXVolume { get { return _sfxVolume; } }
    //setea el valor en el mixer
    public void MasterVolumenActualizer(float sliderVolume)
    {
        _masterVolume = sliderVolume;
        _mixer.SetFloat("MasterVolume", Mathf.Log10(_masterVolume) * 20);
    }
    public void MusicVolumenActualizer(float sliderVolume)
    {
        _musicVolume = sliderVolume;
        _mixer.SetFloat("MusicVolume", Mathf.Log10(_musicVolume) * 20);
    }
    public void SFXVolumenActualizer(float sliderVolume)
    {
        _sfxVolume = sliderVolume;
        _mixer.SetFloat("SFXVolume", Mathf.Log10(_sfxVolume) * 20);
    }
}
