using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class CubeMover : MonoBehaviour
{
    private Vector3 originalScale;
    private Renderer cubeRenderer;
    private Color originalColor;
    private bool isColorChanged = false;
    void Start()
    {
        originalScale = transform.localScale;
        transform.DOMoveX(5f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        cubeRenderer = GetComponent<Renderer>();
        originalColor = cubeRenderer.material.color;
    }
    void Update()
    {
        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            transform.DOScale(originalScale * 2f, 0.5f);
        }
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            transform.DOScale(originalScale, 0.5f);
        }
        if (Keyboard.current.cKey.isPressed && !isColorChanged)
        {
            cubeRenderer.material.DOColor(Color.green, 0.5f);
            isColorChanged = true;
        }
        if (Keyboard.current.cKey. isPressed && isColorChanged)
        {
            cubeRenderer.material.DOColor(originalColor, 0.5f);
            isColorChanged = false;
        }
    }
}
