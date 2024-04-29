using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Slider healthSlider;

    void Start()
    {
        healthSlider.maxValue = healthSlider.value = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().GetHealth();
        scoreText.text = "000000";
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("000000");
    }

    public void UpdateHealth(int health)
    {
        healthSlider.value = health;
    }
}
