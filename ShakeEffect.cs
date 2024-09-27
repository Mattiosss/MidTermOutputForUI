using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeEffect : MonoBehaviour
{
    // Reference to the RectTransform of the UI element you want to shake
    [SerializeField] private RectTransform targetElement;

    // Method that will shake the UI element when invoked
    public void Shake()
    {
        if (targetElement != null)
        {
            // Kill any previous tweens to avoid overlap
            targetElement.DOKill(true);

            // Apply the shake effect using anchored position
            targetElement.DOShakeAnchorPos(0.5f, new Vector2(20f, 20f), 10, 90, false, true);
        }
        else
        {
            Debug.LogError("Target UI element is not assigned in the Inspector!");
        }
    }
}
