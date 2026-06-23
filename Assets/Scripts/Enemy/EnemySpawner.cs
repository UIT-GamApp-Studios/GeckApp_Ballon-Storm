using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private BaseEnemy EnemyPrefab;
    [SerializeField] private float SpawnCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(EnemyPrefab, new Vector3(transform.position.x, Random.Range(-4, 4), 0), transform.rotation);
            yield return new WaitForSeconds(SpawnCooldown);
        }
    }
}
