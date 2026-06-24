using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    private float CurrentShootingType;
    private bool isInCooldown;
    [SerializeField] private float Cooldown;
    [Header("Animator")]
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentShootingType = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Keyboard currentKeyboard = Keyboard.current;
        if (currentKeyboard != null)
        {
            if (currentKeyboard.spaceKey.wasPressedThisFrame)
            {
                if (!isInCooldown) StartCoroutine(DoShoot());
            }
            Key[] numpadKeys = new Key[]{ Key.Digit1, Key.Digit2, Key.Digit3 };
            for (int i = 0; i < numpadKeys.Length; i++)
            {
                var keyToCheck = currentKeyboard[numpadKeys[i]];
                if (keyToCheck.isPressed)
                {
                    CurrentShootingType = i + 1;
                    break;
                }
            }
        }
    }
    private IEnumerator DoShoot()
    {
        isInCooldown = true;
        BaseShootingType[] shootingTypes = GetComponents<BaseShootingType>();
        if (shootingTypes.Length > 0)
        {
            foreach (var shootingType in shootingTypes)
            {
                if (shootingType.ShootingID == CurrentShootingType)
                {
                    animator.SetTrigger("Attack");
                    yield return new WaitForSeconds(0.1f);
                    shootingType.StartCoroutine(shootingType.Shoot());
                    break;
                }
            }
        }
        yield return new WaitForSeconds(Cooldown);
        isInCooldown = false;
    }
}
