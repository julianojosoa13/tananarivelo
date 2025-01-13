using UnityEngine;
using DG.Tweening;

public class FadeInTop : MonoBehaviour
{
    [SerializeField] private RectTransform hudTransform; // The RectTransform of the HUD
    [SerializeField] private float fadeInDuration = 1f; // Duration of the fade-in animation
    [SerializeField] private float moveOffset = 200f; // The distance to move from the top
    [SerializeField] private Ease animationEase = Ease.OutCubic; // Easing type for the animation

    private CanvasGroup canvasGroup; // CanvasGroup to control alpha
    private Vector2 originalPosition; // The original anchored position of the RectTransform

    private void Awake()
    {
        // Ensure the hudTransform is set
        if (hudTransform == null)
            hudTransform = GetComponent<RectTransform>();

        // Get or add a CanvasGroup for controlling alpha
        canvasGroup = hudTransform.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = hudTransform.gameObject.AddComponent<CanvasGroup>();

        // Store the original position
        originalPosition = hudTransform.anchoredPosition;
    }

    private void OnEnable()
    {
        // Reset position and alpha
        ResetHUD();

        // Start the fade-in animation
        AnimateFadeIn();
    }

    private void ResetHUD()
    {
        // Set the initial position above the original position
        hudTransform.anchoredPosition = new Vector2(originalPosition.x, originalPosition.y + moveOffset);

        // Set the alpha to 0 (fully transparent)
        canvasGroup.alpha = 0f;
    }

    private void AnimateFadeIn()
    {
        // Animate position to the original position
        hudTransform.DOAnchorPos(originalPosition, fadeInDuration)
            .SetEase(animationEase);

        // Animate alpha to fully visible
        canvasGroup.DOFade(1f, fadeInDuration);
    }
}
