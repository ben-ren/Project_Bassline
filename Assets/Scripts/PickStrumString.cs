using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickStrumString : MonoBehaviour
{
    public string inputButton;
    public int chainLinkReverseIndex;  //The indexed child (from last-to-first) to apply force to. 
    public float strumForce;
    Transform targetChild = null;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        
        targetChild = this.transform.GetChild(transform.childCount - chainLinkReverseIndex - 1);
        rb2d = targetChild.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //temporary input command. 
        //TODO - Replace with proper controls
        if (Input.GetButtonDown(inputButton))
        {
            Strum();
        }
    }

    void Strum()
    {
        rb2d.AddForce(Vector2.up * strumForce);
    }
}
