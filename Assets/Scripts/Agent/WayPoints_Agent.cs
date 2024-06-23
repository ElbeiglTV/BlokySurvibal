using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints_Agent : SteerinAgent
{

    public Transform[] waypoints;

    private int _currentWaypoint;

    public float waypointDistance;

    private void Update()
    {
        CalculatedNextWaypoint();
        AddForce(Seek(waypoints[_currentWaypoint].position));
        Move();
    }

    void CalculatedNextWaypoint()
    {
        if(Vector3.Distance(transform.position, waypoints[_currentWaypoint].position) < waypointDistance)
            _currentWaypoint++;
        
        if (_currentWaypoint >= waypoints.Length)
            _currentWaypoint = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(waypoints[_currentWaypoint].position, waypointDistance);
    }

}
