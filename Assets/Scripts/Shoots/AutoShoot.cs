using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    [SerializeField] private float shootingCooldown = 0.2f;
    [SerializeField] private float spawnDistance = 0.2f;
    [SerializeField] private BulletPool bulletPrefab;
    [SerializeField] private bool startShoot;
    private float lastShotTime;
    public float ShootingCd
    {
        set { shootingCooldown = value; }
    }
    public bool StartShoot
    {
        set { startShoot = value; }
    }
    public BulletPool BulletPrefab
    {
        set { bulletPrefab = value; }
    }
  
    private void Update()
    {
        if (CanShoot())
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }
    private void Shoot()
    {
        GameObject projectile = ProjectilePool.Instance.GetProjectile(bulletPrefab.typeName);
        Vector3 spawnPosition = transform.position + Vector3.up * spawnDistance;
        projectile.transform.position = spawnPosition;

    }
    private bool CanShoot()
    {
        return  Time.time - lastShotTime > shootingCooldown && startShoot;
    }

}
