using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject[] fishTypes;  //Control in settings
    public int FishTotal;           //Control in settings
    public float spawnRate;         //Control in Settings
    
    private int[] fish_y_pos = {0, -2, -3, -4};
    private bool timeUp;
    private bool spawnFish;
    private float endtime = 0.0f;
    int fishCount = 0;

    private void Start()
    {
        fishCount = SettingsMenu.fishTotal;
        spawnRate = SettingsMenu.spawnRate;
        endtime = Time.time;
        timeUp = false;
        spawnFish = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (fishCount < FishTotal && !UI_Controller.gamePaused) {
            SpawnFish();
        }
    }

    void GenerateFish()
    {
        int randIndex = (int)(Random.value * 4);
        float randomFish = (float)fishTypes.Length * Random.value;
        Vector2 newFishPos = new Vector2(this.transform.position.x, fish_y_pos[randIndex]);
        Instantiate(fishTypes[(int)randomFish], newFishPos, transform.rotation);
    }

    //Fish Spawn logic
    private void SpawnFish()
    {
        FishSpawnRate(spawnRate);
        if (spawnFish)
        {
            GenerateFish();
            fishCount++;
            spawnFish = false;
        }
    }

    //Switches a bool for fish spawning after a time delay
    private void FishSpawnRate(float delay)
    {
        //setup boolean flag to reset times   
        if (endtime <= Time.time)
        {
            timeUp = true;
        }
        if (timeUp)
        {
            //get starttime and endtime
            endtime = Time.time + delay;
            spawnFish = true;
            timeUp = false;
        }
    }
}
