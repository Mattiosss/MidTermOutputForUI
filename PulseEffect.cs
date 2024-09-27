using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PulseEffect : MonoBehaviour
{
    // Reference to the RectTransform of the UI element you want to pulse
    [SerializeField] private RectTransform targetElement;

    // Method to trigger the pulse effect
    public void Pulse()
    {
        if (targetElement != null)
        {
            // Kill any existing tweens on the target to avoid overlap
            targetElement.DOKill(true);

            // Perform a pulse effect by scaling the element up and then back down
            targetElement.DOScale(Vector3.one * 1.2f, 0.2f) // Scale up by 20%
                         .OnComplete(() => 
                            targetElement.DOScale(Vector3.one, 0.2f) // Scale back to original size
                         );
        }
        else
        {
            Debug.LogError("Target UI element is not assigned in the Inspector!");
        }
    }
}
