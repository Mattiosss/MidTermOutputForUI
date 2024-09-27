using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JiggleEffect : MonoBehaviour
{
    // Reference to the RectTransform of the Image that will jiggle
    [SerializeField] private RectTransform targetImage;

    // This method will be called when the button is clicked
    public void Jiggle()
    {
        if (targetImage != null)
        {
            // Kill any previous tweens to avoid overlap
            targetImage.DOKill(true);

            // Apply the jiggle effect using anchor position shake
            targetImage.DOShakeAnchorPos(0.5f, new Vector2(20f, 20f), 10, 90, false, true);

            // Optionally, shake the scale to give a bouncy feel
            targetImage.DOShakeScale(0.5f, new Vector3(0.2f, 0.2f, 0), 10, 90, false);
        }
        else
        {
            Debug.LogError("Target Image not assigned in the Inspector!");
        }
        
    }
}
