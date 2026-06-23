using System.Collections;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    [SerializeField] private float BulletSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SelfDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * BulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseEnemy enemy = collision.GetComponent<BaseEnemy>();
        if (enemy != null)
        {
            enemy.Die();
            Destroy(gameObject);
        }
    }
    private IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
