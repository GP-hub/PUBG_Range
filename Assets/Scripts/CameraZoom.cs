using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera cam; // Reference to the Camera
    public float zoomSpeed = 2f; // Speed of zooming
    public float minZoom = 2f; // Minimum zoom level
    public float maxZoom = 10f; // Maximum zoom level

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main; // Automatically find the main camera
        }
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); // Get mouse wheel input

        if (scroll != 0)
        {
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
