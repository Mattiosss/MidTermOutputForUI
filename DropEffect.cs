using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DropEffect : MonoBehaviour
{
    // Reference to the RectTransform of the UI element to drop
    [SerializeField] private RectTransform targetElement;

    // Duration of the drop effect
    [SerializeField] private float dropDuration = 0.5f;

    // Offset to move the element from (for example, starting from above the screen)
    [SerializeField] private float dropOffset = 800f;

    // Method to trigger the drop effect
    public void Drop()
    {
        if (targetElement != null)
        {
            // Kill any existing tweens to avoid overlap
            targetElement.DOKill(true);

            // Move the element above its original position by the dropOffset
            targetElement.anchoredPosition = new Vector2(targetElement.anchoredPosition.x, targetElement.anchoredPosition.y + dropOffset);

            // Drop the element back to its original position over the specified duration
            targetElement.DOAnchorPosY(targetElement.anchoredPosition.y - dropOffset, dropDuration).SetEase(Ease.OutBounce);
        }
        else
        {
            Debug.LogError("Target UI element is not assigned in the Inspector!");
        }
    }   
}
