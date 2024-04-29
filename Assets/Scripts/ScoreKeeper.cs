using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int curScore = 0;

    public int GetScore() => curScore;
    public void Reset() => curScore = 0;
    public void AddToScore(int score)
    {
        curScore += score;
        Mathf.Clamp(curScore, 0, int.MaxValue);
    } 
}
