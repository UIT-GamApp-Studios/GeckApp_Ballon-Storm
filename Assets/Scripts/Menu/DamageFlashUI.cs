using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlashUI : MonoBehaviour
{
    [SerializeField] private Image redBorderImage;

    [Header("Flash Settings")]
    [Tooltip("Max opacity of the flash (0 to 1)")]
    [Range(0f, 1f)] public float maxAlpha = 0.6f;
    
    [Tooltip("Time to fade in")]
    public float flashInDuration = 0.05f;
    
    [Tooltip("Time to fade out")]
    public float flashOutDuration = 0.3f;

    private int lastLivesCount;
    private Coroutine flashCoroutine;

    private void OnEnable()
    {
        PlayerHealth.OnHealthChanged += HandleHealthChanged;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= HandleHealthChanged;
    }

    private void Start()
    {
        if (redBorderImage != null)
        {
            Color c = redBorderImage.color;
            c.a = 0f;
            redBorderImage.color = c;
        }

        lastLivesCount = 3; 
    }

    private void HandleHealthChanged(int currentLives)
    {
        if (currentLives < lastLivesCount)
        {
            if (flashCoroutine != null) StopCoroutine(flashCoroutine);
            flashCoroutine = StartCoroutine(FlashRedBorder());
        }

        lastLivesCount = currentLives;
    }

    private IEnumerator FlashRedBorder()
    {
        if (redBorderImage == null) yield break;

        Color targetColor = redBorderImage.color;
        float elapsed = 0f;

        while (elapsed < flashInDuration)
        {
            elapsed += Time.deltaTime;
            targetColor.a = Mathf.Lerp(0f, maxAlpha, elapsed / flashInDuration);
            redBorderImage.color = targetColor;
            yield return null;
        }

        targetColor.a = maxAlpha;
        redBorderImage.color = targetColor;

        elapsed = 0f;
        while (elapsed < flashOutDuration)
        {
            elapsed += Time.deltaTime;
            targetColor.a = Mathf.Lerp(maxAlpha, 0f, elapsed / flashOutDuration);
            redBorderImage.color = targetColor;
            yield return null;
        }

        targetColor.a = 0f;
        redBorderImage.color = targetColor;
    }
}