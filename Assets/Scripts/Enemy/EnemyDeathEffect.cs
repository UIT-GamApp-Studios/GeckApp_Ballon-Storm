using System.Collections;
using UnityEngine;

public class EnemyDeathEffect : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 0.4f;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float t = 0;
        Color c = sr.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = 1f - (t / fadeDuration);
            sr.color = c;
            yield return null;
        }

        Destroy(gameObject);
    }
}