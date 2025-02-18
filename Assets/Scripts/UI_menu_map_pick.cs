using UnityEngine;

public class UI_menu_map_pick : MonoBehaviour
{
    // Reference to the Canvas to be disabled
    [SerializeField] private Canvas targetCanvasEnable;
    [SerializeField] private Canvas targetCanvasDisable;

    // Method to disable the Canvas
    public void EnableDisableCanvas()
    {
        if (targetCanvasDisable != null)
        {
            targetCanvasEnable.gameObject.SetActive(true);
            targetCanvasDisable.gameObject.SetActive(false);
        }
    }
}