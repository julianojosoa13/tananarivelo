using UnityEngine;
using DG.Tweening;

public class BounceOnEnable : MonoBehaviour
{
    [SerializeField] private Transform bounceObject; // The object to scale (e.g., "E interact")
    [SerializeField] private float bounceDuration = 0.5f; // Duration of one bounce cycle
    [SerializeField] private float bounceScaleMultiplier = 1.2f; // Scale multiplier for the bounce
    [SerializeField] private int bounceLoops = -1; // Number of bounces (-1 for infinite)

    private Vector3 originalScale; // Original scale of the object

    private void Awake()
    {
        // Ensure the object reference is set
        if (bounceObject == null)
            bounceObject = transform;

        // Store the original scale
        originalScale = bounceObject.localScale;
    }

    private void OnEnable()
    {
        // Reset scale to the original size
        bounceObject.localScale = originalScale;

        // Start the bounce animation
        BounceAnimation();
    }

    private void OnDisable()
    {
        // Stop the animation and reset the scale
        bounceObject.DOKill(); // Stop any running DOTween animation
        bounceObject.localScale = originalScale;
    }

    private void BounceAnimation()
    {
        // Create a scaling animation for the bounce effect
        bounceObject.DOScale(originalScale * bounceScaleMultiplier, bounceDuration / 2)
                    .SetEase(Ease.OutQuad)
                    .SetLoops(bounceLoops, LoopType.Yoyo);
    }
}
