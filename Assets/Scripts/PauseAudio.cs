using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PauseAudio : MonoBehaviour
{
    private AudioSource aud;

    void Start()
    {
        aud = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        SetAudioVolume();
        if (UI_Controller.gamePaused)
        {
            
            aud.mute = true;
        }
        else
        {
            aud.mute = false;
        }
    }

    private void SetAudioVolume()
    {
        aud.volume = SettingsMenu.volume;
    }
}
