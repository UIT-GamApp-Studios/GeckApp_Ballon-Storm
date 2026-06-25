using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image[] heartImages;

    private void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHealthUI;
    }
    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealthUI;
    }

    private void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].enabled = (i < currentHealth);
        }
    }
}
