using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TadaEffect : MonoBehaviour
{
   // Reference to the RectTransform of the UI element for the Tada effect
    [SerializeField] private RectTransform targetElement;
    
    // Rotation angle for the wobble effect (in degrees)
    [SerializeField] private float wobbleAngle = 15f;

    // Method to trigger the Tada animation
    public void Tada()
    {
        if (targetElement != null)
        {
            // Kill any existing tweens to avoid overlap
            targetElement.DOKill(true);

            // Reset scale and rotation before starting
            targetElement.localScale = Vector3.one;
            targetElement.localRotation = Quaternion.identity;

            // Create a sequence for the Tada effect
            Sequence tadaSequence = DOTween.Sequence();

            // First: Scale up quickly, then scale down with a slight overshoot
            tadaSequence.Append(targetElement.DOScale(1.1f, 0.2f).SetEase(Ease.OutQuad))
                        .Append(targetElement.DOScale(0.9f, 0.2f).SetEase(Ease.InQuad))
                        .Append(targetElement.DOScale(1.0f, 0.2f).SetEase(Ease.OutBounce));

            // Add a controlled back-and-forth wobble using rotation
            tadaSequence.Join(targetElement.DORotate(new Vector3(0, 0, wobbleAngle), 0.15f).SetEase(Ease.InOutSine))
                        .Append(targetElement.DORotate(new Vector3(0, 0, -wobbleAngle), 0.15f).SetEase(Ease.InOutSine))
                        .Append(targetElement.DORotate(new Vector3(0, 0, wobbleAngle / 2), 0.1f).SetEase(Ease.InOutSine))
                        .Append(targetElement.DORotate(Vector3.zero, 0.1f).SetEase(Ease.InOutSine));

            // Play the entire sequence
            tadaSequence.Play();
        }
        else
        {
            Debug.LogError("Target UI element is not assigned in the Inspector!");
        }
    }
}
