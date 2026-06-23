using System.Collections;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected float EnemySpeed;
    [SerializeField] protected float EnemyScore;
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
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.gameObject.GetComponent<PlayerMove>();
        if (player != null)
        {
            Destroy(player.gameObject);
            GameUI.instance.Pause();
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
