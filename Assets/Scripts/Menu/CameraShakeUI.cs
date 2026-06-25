using UnityEngine;
using Unity.Cinemachine;

public class CameraShakeUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CinemachineImpulseSource impulseSource;

    [Header("Shake Settings")]
    [Tooltip("Global multiplier for shake force")]
    public float shakeForceMultiplier = 1f;

    private int lastLivesCount;

    private void OnEnable()
    {
        // Đăng ký lắng nghe sự kiện từ PlayerHealth
        PlayerHealth.OnHealthChanged += HandleHealthChanged;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= HandleHealthChanged;
    }

    private void Start()
    {
        if (impulseSource == null)
        {
            impulseSource = GetComponent<CinemachineImpulseSource>();
        }

        lastLivesCount = 3;
    }

    private void HandleHealthChanged(int currentLives)
    {
        if (currentLives < lastLivesCount)
        {
            TriggerShake();
        }

        lastLivesCount = currentLives;
    }

    private void TriggerShake()
    {
        if (impulseSource != null)
        {
            Vector3 randomVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
            impulseSource.GenerateImpulseWithVelocity(randomVelocity * shakeForceMultiplier);
        }
    }
}