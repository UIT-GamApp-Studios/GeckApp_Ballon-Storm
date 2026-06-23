using System.Collections;
using UnityEngine;

public class Tanker : BaseEnemy
{
    private int isUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isUp = 1;
        StartCoroutine(UpDown());
    }
    public override void Move()
    {
        base.Move();
        if (Mathf.Abs(transform.position.y) > 4)
        {
            isUp *= -1;
        }
        transform.position += new Vector3(0, isUp * EnemySpeed * Time.deltaTime, 0);
    }
    private IEnumerator UpDown()
    {
        while (true)
        {
            isUp = 1;
            yield return new WaitForSeconds(2);
            isUp = -1;
            yield return new WaitForSeconds(2);
        }
    }
}
