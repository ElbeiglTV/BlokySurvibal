using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAgent : SteerinAgent
{
    public SteerinAgent target;

    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;

    private void Update()
    {
        if(_maxDistance > _minDistance)
        {
            AddForce(Pursuit(target));
        }
        else
        {
            AddForce(Evade(target));
        }
        Move();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(target.transform.position, _maxDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(target.transform.position, _minDistance);
    }
}
