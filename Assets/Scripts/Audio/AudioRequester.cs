using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//TPFinal - Matias Labreniuk - Gael Taborda
public class AudioRequester : MonoBehaviour
{
    [SerializeField] AudioSource _audioSourceSfx;
    [SerializeField] AudioSource _audioSourceMusic;

    private static AudioRequester instance;
    public static AudioRequester Instance { get { return instance; } }

    private void Awake()
    {
        Singletoner();
    }

    private AudioClip RecuestAudioClip(string Audioname)
    {
        return Resources.Load<AudioClip>(Audioname);
    }

    public void AudioPlayerOneShoot(string audioclipname, string type, int priority)//metodo al que le paso el nombre de el audio y su typo ya sea sfx o music 
    {
        if (type == "sfx")
        {
            _audioSourceSfx.priority = priority;
            _audioSourceSfx.PlayOneShot(RecuestAudioClip(audioclipname));//play al audio si es sfx
        }
        if (type == "music") _audioSourceMusic.PlayOneShot(RecuestAudioClip(audioclipname));//play al audio si es music
    }

    public void DelayPlay(string audioname, float delay, bool Loop)
    {
        _audioSourceMusic.clip = RecuestAudioClip(audioname);
        _audioSourceMusic.PlayDelayed(delay);
        _audioSourceMusic.loop = Loop;
    }

    public void StopSong()
    {
        _audioSourceMusic.Stop();
    }

    public float AudioLength(string audioname)
    {
        return RecuestAudioClip(audioname).length;
    }

    private void Singletoner()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
