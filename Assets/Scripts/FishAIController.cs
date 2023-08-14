using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAIController : MonoBehaviour
{
    public Vector2 initialTarget;
    public float speed;
    public float biteTime;
    public bool bite;
    public int scoreValue;

    private float tempSpeed;
    private bool triggerEntered = false;
    private Vector2 newTarget;
    private GameObject collidedTrigger;

    // Start is called before the first frame update
    void Start()
    {
        tempSpeed = speed;
        bite = true;
        newTarget = initialTarget;
    }

    // Update is called once per frame
    void Update()
    {
        BiteLogic();
        Move(newTarget);
    }

    //Move's Fish to target location
    void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    //The timer for how long the fish bite lasts
    private IEnumerator SwitchBoolAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        bite = false;
    }

    //Checks logic during fish bite
    void BiteLogic()
    {
        if (!bite)
        {
            speed = tempSpeed;
            newTarget = initialTarget;
        }
        if (bite && collidedTrigger != null)
        {
            speed = 10f;
            newTarget = collidedTrigger.transform.position;
        }
    }

    //check if in hook hitbox, if true then transform.position = other.transform.positiion. 
    private void OnTriggerStay2D(Collider2D other)
    {
        collidedTrigger = other.gameObject;
        //starts the bite timer
        if (!triggerEntered && other.transform.CompareTag("Hook"))
        {
            triggerEntered = true;
            StartCoroutine(SwitchBoolAfterDelay(biteTime));
        }
    }
}
