using System.Collections;
using UnityEngine;

public class ShootingType2 : BaseShootingType
{
    [SerializeField] private GameObject HeadGun1;
    [SerializeField] private GameObject HeadGun2;
    public override IEnumerator Shoot()
    {
        Instantiate(Bullet, HeadGun.transform.position, transform.rotation * Quaternion.Euler(0, 0, -90f));
        Instantiate(Bullet, HeadGun1.transform.position, transform.rotation * Quaternion.Euler(0, 0, -90f));
        Instantiate(Bullet, HeadGun2.transform.position, transform.rotation * Quaternion.Euler(0, 0, -90f));
        yield return null;
    }
}
