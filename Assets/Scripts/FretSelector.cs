using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FretSelector : MonoBehaviour
{
    public Camera cam;
    public GameObject guitar;
    protected int FretIndex;
    private float camOrthRadius;
    float x = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //calculates the camera's boundries
        //(plus an offset to keep the gameObject visible in the camera)
        camOrthRadius = (cam.orthographicSize * 2) - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        UseMouse();
    }

    void UseButtons()
    {
        float moveVar = (Input.GetAxis("Horizontal") * 0.1f);
        //Calculates the x position relative to the Input
        //Uses Mathf.Clamp to set this FretSelector's movement to within the camera boundaries
        x = Mathf.Clamp(x + moveVar, -camOrthRadius, camOrthRadius);
        MoveSelector(x);
    }

    void UseMouse()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePositionScreen = Input.mousePosition;
        // Convert the screen coordinates to world coordinates
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        // Get the x position of the mouse relative to the screen's position
        float mouseXPosOnScreen = mousePositionWorld.x;
        MoveSelector(mouseXPosOnScreen);
    }

    //Move's the FretSelector along the x-axis
    private void MoveSelector(float x_pos)
    {
        transform.position = new Vector2(x_pos, guitar.transform.position.y);
    }

    public int GetFretIndex()
    {
        return FretIndex;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.IsChildOf(guitar.transform))
        {
            FretIndex = other.transform.GetSiblingIndex();
        }
    }
}
