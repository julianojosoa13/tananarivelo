using UnityEngine;
using DG.Tweening;

public class DisableAfterSeconds : MonoBehaviour
{
    [SerializeField] private RectTransform targetTransform; // The RectTransform to move
    [SerializeField] private float moveDuration = 1f; // Duration of the move animation
    [SerializeField] private float disableDelay = 60f; // Time to wait before disabling, including animation time
    [SerializeField] private float offscreenOffset = -500f; // Offset to move the object offscreen

    private Vector3 originalPosition;

    private void Awake()
    {
        // Ensure the targetTransform is set
        if (targetTransform == null)
            targetTransform = GetComponent<RectTransform>();

        // Store the original position
        originalPosition = targetTransform.anchoredPosition;
    }

    private void OnEnable()
    {
        // Cancel any existing tweens or delayed actions
        targetTransform.DOKill();
        CancelInvoke(nameof(DisableObject));

        // Reset to the original position
        targetTransform.anchoredPosition = originalPosition;

        // Schedule the disable process
        Invoke(nameof(DisableObject), disableDelay);
    }

    private void OnDisable()
    {
        // Stop any active tweens or invokes
        targetTransform.DOKill();
        CancelInvoke(nameof(DisableObject));
    }

    private void DisableObject()
    {
        // Move the object down offscreen
        targetTransform.DOAnchorPos(new Vector2(originalPosition.x, originalPosition.y + offscreenOffset), moveDuration)
            .SetEase(Ease.InQuad)
            .OnComplete(() =>
            {
                // Disable the GameObject after the animation
                gameObject.SetActive(false);
            });
    }
}
