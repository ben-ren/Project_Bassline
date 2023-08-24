using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Canvas))]
public class UI_Controller : MonoBehaviour
{
    public FishCollectorController collector;
    public TextMeshProUGUI text;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        text.text = "Score: " + collector.GetFishScore(); 
    }
}