using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    //[SerializeField] private AudioSource _musicSource;

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            //AudioRequester.Instance.StopSong();
            AudioRequester.Instance.DelayPlay("Main Menu",0.1f,true);
        }
        else
        {
            AudioRequester.Instance.StopSong();
            AudioRequester.Instance.DelayPlay("Level", 0.1f, true);
        }
    }
}
