using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    
    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointId = 0;

    void Start()
    {
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
