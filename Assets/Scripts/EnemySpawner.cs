using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO curWave;

    public WaveConfigSO GetCurrentWave() => curWave;
    
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < curWave.GetEnemyCount(); i++)
        {
            Instantiate(curWave.GetEnemyPrefab(i), curWave.GetFirstWaypoint().position, Quaternion.identity, transform);
        }
    }
}
