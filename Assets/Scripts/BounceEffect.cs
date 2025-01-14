using UnityEngine;
using DG.Tweening;

public class BounceEffect : MonoBehaviour
{
    [Header("Bounce Settings")]
    public Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f); // Scale to bounce to
    public float duration = 0.3f; // Duration of the bounce effect

    private Vector3 originalScale; // Stores the initial scale of the object

    private void Awake()
    {
        // Save the original scale of the object
        originalScale = transform.localScale;
    }

    /// <summary>
    /// Triggers the bounce effect.
    /// </summary>
    public void Bounce()
    {
        // Scale to the target scale and back to the original
        transform.DOScale(targetScale, duration / 2)
                 .OnComplete(() => transform.DOScale(originalScale, duration / 2));
    }
}
