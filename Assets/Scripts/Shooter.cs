using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Shooter Settings")]
    [SerializeField] float shotSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float shootingRate = 1f;
    
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float shootingRandomness = 0f;
    [SerializeField] float minShootingRate = 0.2f;
    [HideInInspector] public bool isFiring;

    Coroutine shootingCoroutine;

    void Start()
    {
        isFiring = useAI;
    }

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
            GameObject projectile = Instantiate(projectilePrefab, transform.position, 
                                    useAI ? Quaternion.Euler(0, 0, 180) : Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = transform.up * shotSpeed;
            }

            Destroy(projectile, projectileLifetime);

            float timeToShoot = Random.Range(shootingRate - shootingRandomness, shootingRate + shootingRandomness);
            yield return new WaitForSeconds(Mathf.Clamp(timeToShoot, minShootingRate, float.MaxValue));
        }
    }
}
