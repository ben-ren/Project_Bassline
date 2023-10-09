using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;
    public FretSelector fret;

    //Octave's are scaled at tthe 12th root of 2.
    //The frequency ratio (musical interval) of a semitone in twelve-tone equal temperament
    //Simple Terms: the freqency needed to increase a note by 1.
    private float scale = Mathf.Pow(2f, 1f / 12f);

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        fret = fret.GetComponent<FretSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAudioVolume();
        int pressedButton = CheckButtonPressed();

        PitchShift();

        if (pressedButton != -1)
        {
            PlayAudio(pressedButton);
        }
    }

    //Selects the AudioClip index based on the inputString
    int CheckButtonPressed()
    {
        if (Input.GetButtonDown("Strum1"))
        {
            return 0;
        } 
        else if (Input.GetButtonDown("Strum2"))
        {
            return 1;
        }
        else if (Input.GetButtonDown("Strum3"))
        {
            return 2;
        }
        else if (Input.GetButtonDown("Strum4"))
        {
            return 3;
        }
        return -1;
    }

    //plays the audioClip from the selected index.
    private void PlayAudio(int index)
    {
        if (index >= 0 && index < audioClip.Length)
        {
            audioSource.clip = audioClip[index];
            audioSource.Play();
        }
    }

    //Shifts the pitch of the AudioSource component based on the FretSelector Index
    private void PitchShift()
    {
        //https://discussions.unity.com/t/pitch-in-unity/22657/6
        int fretIndex = fret.GetFretIndex();
        audioSource.pitch = Mathf.Pow(scale, fretIndex);
    }

    private void SetAudioVolume()
    {
        audioSource.volume = SettingsMenu.volume;
    }
}
