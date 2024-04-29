using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool shouldShakeOnHit;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindFirstObjectByType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DealDamage dealDamage = other.GetComponent<DealDamage>();
        if (dealDamage != null)
        {
            TakeDamage(dealDamage.GetDamage());
            dealDamage.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        ShakeCamera();
        if (health <= 0)
        {
            Destroy(gameObject);
            audioPlayer.PlayExplosionClip();
            PlayParticleEffect();
        }
    }

    void PlayParticleEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem particle = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(particle.gameObject, particle.main.duration + particle.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (cameraShake == null || !shouldShakeOnHit)
            return;
        
        audioPlayer.PlayDamageClip();
        cameraShake.Shake();
    }
}
