using UnityEngine;

public class Horse : BaseEnemy
{
    public override void Move()
    {
        base.Move();
        transform.position += new Vector3(-EnemySpeed * Time.deltaTime, 0, 0);
    }
}
