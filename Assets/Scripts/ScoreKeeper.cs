using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    int curScore = 0;
    public int GetScore() => curScore;
    public void Reset() => curScore = 0;
    public void AddToScore(int score)
    {
        curScore += score;
        Mathf.Clamp(curScore, 0, int.MaxValue);
    } 
}
