using System.Collections;
using UnityEngine;

public class ShootingType3 : BaseShootingType
{
    public override IEnumerator Shoot()
    {
        for (int i = 1; i <= 3; i++)
        {
            Instantiate(Bullet, HeadGun.transform.position, transform.rotation * Quaternion.Euler(0, 0, i * 15f - 30f) * Quaternion.Euler(0, 0, -90f));
        }
        yield return null;
    }
}
