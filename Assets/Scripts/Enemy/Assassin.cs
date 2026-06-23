using UnityEngine;

public class Assassin : BaseEnemy
{
    public override void Move()
    {
        base.Move();
        if (PlayerMove.Instance != null)
        {
            float PlayerAngle = Mathf.Atan2(transform.position.y - PlayerMove.Instance.transform.position.y, transform.position.x - PlayerMove.Instance.transform.position.x) * Mathf.Rad2Deg;
            Quaternion Angle = Quaternion.Euler(0, 0, PlayerAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, Angle, EnemySpeed);
            transform.position += -transform.right * EnemySpeed * Time.deltaTime;
        }
    }
}
