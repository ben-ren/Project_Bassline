using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider countSlider;
    public Slider spawnRateSlider;

    [HideInInspector] public static float volume;
    [HideInInspector] public static int fishTotal;
    [HideInInspector] public static float spawnRate;
    //May include FishType later

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        countSlider.onValueChanged.AddListener(delegate { ChangeCount(); });
        spawnRateSlider.onValueChanged.AddListener(delegate { ChangeRate(); });
    }

    public void ChangeVolume()
    {
        volume  = volumeSlider.value;
    }

    public void ChangeCount()
    {
        fishTotal = (int)(countSlider.value * 100);
    }

    public void ChangeRate()
    {
        spawnRate = spawnRateSlider.value;
    }

}
