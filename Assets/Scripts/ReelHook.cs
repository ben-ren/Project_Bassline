using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelHook : MonoBehaviour
{
    public string inputButton;
    public float speed;
    public float y_shift;

    private float original_y;
    protected bool reelLine;
    private Vector2 startPos;
    private Vector2 topPos;

    // Start is called before the first frame update
    void Start()
    {
        original_y = transform.position.y;
        startPos = transform.position;
        topPos = new Vector2(transform.position.x, transform.position.y + y_shift);
    }

    // Update is called once per frame
    void Update()
    {
        if (!UI_Controller.gamePaused)
        {
            UpdateXPos();
            HookReelCycle();
        }
    }

    void UpdateXPos()
    {
        Vector3 temp = new Vector3(transform.position.x, original_y, transform.position.z);
        if (!reelLine && transform.position == temp)
        {
            startPos = transform.position;
            topPos = new Vector2(transform.position.x, transform.position.y + y_shift);
        }   
    }

    void HookReelCycle()
    {
        bool input = Input.GetButton(inputButton);
        
        if (input)
        {
            reelLine = true;
            transform.position = Vector2.MoveTowards(transform.position, topPos, speed);
        }
        else if(!input)
        { 
            reelLine = false;
            transform.position = Vector2.MoveTowards(transform.position, startPos, speed);
        }
    }
}
