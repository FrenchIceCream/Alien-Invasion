using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WaveConfigSO curWave;

    public WaveConfigSO GetCurrentWave() => curWave;
    
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            for (int j = 0; j < waveConfigs.Count; j++)
            {
                curWave = waveConfigs[j];
                for (int i = 0; i < curWave.GetEnemyCount(); i++)
                {
                    Instantiate(curWave.GetEnemyPrefab(i), curWave.GetFirstWaypoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(curWave.GetSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (true);
    }
}
