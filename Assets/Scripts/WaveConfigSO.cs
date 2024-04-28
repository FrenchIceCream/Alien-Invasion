using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Config", menuName = "Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemySpeed = 5f;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnTimeRange = 0f;
    [SerializeField] float minSpawnTime = 0.3f;

    public float GetEnemySpeed() => enemySpeed;
    public int GetEnemyCount() => enemyPrefabs.Count;
    public GameObject GetEnemyPrefab(int index) => enemyPrefabs[index];
    public Transform GetFirstWaypoint() => pathPrefab.GetChild(0);
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform waypoint in pathPrefab)
            waypoints.Add(waypoint);
        
        return waypoints;
    }

    public float GetSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenSpawns - spawnTimeRange, timeBetweenSpawns + spawnTimeRange);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }
}
