using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollectorController : MonoBehaviour
{
    private int fishScore;

    public int GetFishScore()
    {
        return fishScore;
    }

    public int AddScore(int value)
    {
        return fishScore + value;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            fishScore = AddScore(other.GetComponent<FishAIController>().scoreValue);
            Destroy(other.gameObject, .5f);
        }
    }
}
