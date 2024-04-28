using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    EnemySpawner enemySpawner;
    List<Transform> waypoints;
    WaveConfigSO waveConfig;
    int waypointId = 0;

    void Awake()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointId].transform.position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointId < waypoints.Count)
        {
            Vector3 targetPos = waypoints[waypointId].position;
            float offset = waveConfig.GetEnemySpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, offset);
            
            if (targetPos == transform.position)
                waypointId++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
