using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ZoomEffect : MonoBehaviour
{
    // Reference to the RectTransform of the UI element to zoom
    [SerializeField] private RectTransform targetElement;

    // Duration of the zoom effect
    [SerializeField] private float zoomDuration = 0.5f;

    // The scale factor for zooming in (default is 1 for no zoom, larger for zoom in)
    [SerializeField] private float zoomInScale = 1.2f;

    // Method to zoom in (increase scale)
    public void ZoomIn()
    {
        if (targetElement != null)
        {
            // Kill any existing tweens to avoid overlap
            targetElement.DOKill(true);

            // Apply the zoom in effect (scaling up)
            targetElement.DOScale(Vector3.one * zoomInScale, zoomDuration).SetEase(Ease.InOutQuad);
        }
        else
        {
            Debug.LogError("Target UI element is not assigned in the Inspector!");
        }
    }

    // Method to zoom out (reset scale to original)
    public void ZoomOut()
    {
        if (targetElement != null)
        {
            // Kill any existing tweens to avoid overlap
            targetElement.DOKill(true);

            // Apply the zoom out effect (scaling back to original size)
            targetElement.DOScale(Vector3.one, zoomDuration).SetEase(Ease.InOutQuad);
        }
        else
        {
            Debug.LogError("Target UI element is not assigned in the Inspector!");
        }
    }
}
