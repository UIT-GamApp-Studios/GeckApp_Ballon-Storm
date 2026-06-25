using System.Collections;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected float EnemySpeed;
    [SerializeField] protected float EnemyScore;
    [SerializeField] private GameObject deathEffectPrefab;
    private bool DoSelfDestroy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DoSelfDestroy = false;
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        if (transform.position.x < -30) SelfDestroy();
    }
    public void Die()
    {
        if (deathEffectPrefab != null)
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage();
            Die();
        }
    }
    private void SelfDestroy()
    {
        DoSelfDestroy = true;
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (!DoSelfDestroy) GameScore.instance.AddScore(EnemyScore);
    }
}
