using TMPro;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    private bool firstClick = false;
    private Vector2 firstPoint, secondPoint;
    private Vector2 mouseStartPosition;
    private bool isDragging = false;
    private float dragThreshold = 0.1f; // Minimum movement to be considered a drag
    [SerializeField] private TextMeshProUGUI distanceDisplay;

    void Start()
    {
        lineRenderer.positionCount = 0; // Start with no positions
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click pressed
        {
            // Get the mouse position in screen space (pixels)
            mouseStartPosition = Input.mousePosition;
            isDragging = false; // Reset drag flag when the click starts
        }

        if (Input.GetMouseButton(0)) // Holding left-click
        {
            Vector2 currentMousePosition = (Vector2)Input.mousePosition;
            if (Vector2.Distance(mouseStartPosition, currentMousePosition) > dragThreshold)
            {
                isDragging = true; // If movement exceeds threshold, it's a drag
            }
        }

        if (Input.GetMouseButtonUp(0)) // Left-click released
        {
            Vector2 mousePosition = (Vector2)Input.mousePosition;

            // Only draw if there's no drag and the position is the same
            if (!isDragging && mousePosition == mouseStartPosition)
            {
                // Convert screen space positions to world space
                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

                // Set first point
                firstPoint = worldPosition;
                lineRenderer.positionCount = 2; // Make sure there are 2 points
                lineRenderer.SetPosition(0, firstPoint); // Set first point
                firstClick = true;

                if (lineRenderer.GetPosition(1) == Vector3.zero)
                {
                    lineRenderer.positionCount = 1;
                }

                CalculateDistance();

            }
            // Do NOT reset line if there's a drag, just prevent drawing.
            isDragging = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Vector2 mousePosition = (Vector2)Input.mousePosition;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // Set second point
            secondPoint = worldPosition;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(1, secondPoint); // Set second point
            firstClick = false;

            CalculateDistance();
        }

        // Do not reset the line when dragging occurs, only reset after a valid click-release
    }

    private void CalculateDistance()
    {

        if (lineRenderer.positionCount == 2)
        {
            // Calculate distance
            float distance = (Vector2.Distance(firstPoint, secondPoint)) * 666f;
            int d = (int)distance;
            distanceDisplay.text = d.ToString();
        }
    }
}
