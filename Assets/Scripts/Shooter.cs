using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] float shotSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float shootingRate = 1f;
    public bool isFiring;

    Coroutine shootingCoroutine;

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (isFiring && shootingCoroutine == null)
            shootingCoroutine = StartCoroutine(ShootContiniously());
        else if (!isFiring && shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    IEnumerator ShootContiniously()
    {
        while (true)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = transform.up * shotSpeed;
            }

            Destroy(projectile, projectileLifetime);
            yield return new WaitForSeconds(shootingRate);
        }
    }
}
