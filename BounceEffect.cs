using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceEffect : MonoBehaviour
{
     // Reference to the RectTransform of the UI element for the Bounce effect
    [SerializeField] private RectTransform targetElement;

    // Duration of the entire bounce effect
    [SerializeField] private float bounceDuration = 0.5f;

    // Bounce height (how much the element moves up)
    [SerializeField] private float bounceHeight = 50f;

    // Method to trigger the Bounce animation
    public void Bounce()
    {
        if (targetElement != null)
        {
            // Kill any existing tweens to avoid overlap
            targetElement.DOKill(true);

            // Reset the element's position before starting
            targetElement.anchoredPosition = Vector2.zero;

            // Create a sequence for the Bounce effect
            Sequence bounceSequence = DOTween.Sequence();

            // Move up and then down with elastic bounce
            bounceSequence.Append(targetElement.DOAnchorPosY(bounceHeight, bounceDuration / 2).SetEase(Ease.OutQuad))
                          .Append(targetElement.DOAnchorPosY(0f, bounceDuration / 2).SetEase(Ease.OutBounce));

            // Play the bounce sequence
            bounceSequence.Play();
        }
        else
        {
            Debug.LogError("Target UI element is not assigned in the Inspector!");
        }
    }
}
