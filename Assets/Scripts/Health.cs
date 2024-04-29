using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool isPlayer;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    UIDisplay uiDisplay;
    public int GetHealth() => health;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindFirstObjectByType<AudioPlayer>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        uiDisplay = FindFirstObjectByType<UIDisplay>();
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
        if (isPlayer)
            uiDisplay.UpdateHealth(health);
        ShakeCamera();
        if (health <= 0)
        {
            IncreaseScore();
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
        if (cameraShake == null || !isPlayer)
            return;
        
        audioPlayer.PlayDamageClip();
        cameraShake.Shake();
    }

    void IncreaseScore()
    {
        if (scoreKeeper == null || isPlayer)
            return;
        
        scoreKeeper.AddToScore(score);
        uiDisplay.UpdateScore(scoreKeeper.GetScore());
    }
}
