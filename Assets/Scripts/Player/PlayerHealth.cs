using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int livesCount = 3;

    public static event Action<int> OnHealthChanged;

    void Start()
    {
        Reset();
    }

    public void TakeDamage()
    {
        livesCount -= 1;
        OnHealthChanged?.Invoke(livesCount);

        if (livesCount <= 0)
        {
            Destroy(gameObject);
            GameUI.instance.LoseGame();
        }
    }

    void Reset()
    {
        livesCount = 3;
        OnHealthChanged?.Invoke(livesCount);
    }
}
