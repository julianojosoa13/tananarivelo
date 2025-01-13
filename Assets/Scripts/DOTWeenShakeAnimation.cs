using System.Collections;
using UnityEngine;
using DG.Tweening;

public class DOTWeenShakeAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform uiElement; // The UI element to shake.
    [SerializeField] private float duration = 1f; // Total duration of the shake.
    [SerializeField] private float strength = 10f; // Shake strength (distance to move).
    [SerializeField] private int vibrato = 10; // Number of shakes during the duration.
    [SerializeField] private float randomness = 90f; // Randomness of the shake movement.

    // Start is called before the first frame update
    void Start()
    {
        if (uiElement == null)
        {
            Debug.LogError("UI Element is not assigned!");
            return;
        }

        ShakeUI();
    }

    private void OnEnable()
    {
        if (uiElement == null)
        {
            Debug.LogError("UI Element is not assigned!");
            return;
        }

        ShakeUI();
    }

    private void ShakeUI()
    {
        // Shake the UI element using DOTween
        uiElement.DOShakeAnchorPos(duration, strength, vibrato, randomness)
                 .SetEase(Ease.OutQuad)
                 .OnComplete(() => Debug.Log("Shake Complete"));
    }
}

