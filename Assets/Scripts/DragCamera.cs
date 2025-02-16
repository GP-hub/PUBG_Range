using UnityEngine;

public class DragCamera : MonoBehaviour
{
    public float dragSpeed = 1f; // Speed of camera movement
    private Vector3 dragOrigin; // Where the drag started
    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click pressed
        {
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        if (Input.GetMouseButton(0)) // Holding left-click
        {
            if (isDragging)
            {
                Vector3 difference = dragOrigin - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += difference; // Move the camera
            }
        }

        if (Input.GetMouseButtonUp(0)) // Left-click released
        {
            isDragging = false;
        }
    }
}
