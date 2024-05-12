using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitAgent : SteerinAgent
{
    //Fijar objetivo
    public Transform player;
    private float _currentSpeed;
    private float _currentForce;
    
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _visionDistance;

    private void Start()
    {
        _currentSpeed = _maxSpeed;
        _currentForce = _maxForce;
    }

    private void Update()
    {
        CheckDistanceAndMove();


    }

    private void CheckDistanceAndMove()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > _maxDistance && distanceToPlayer < _visionDistance)
        {
            Movement();
        }
        else if (distanceToPlayer < _maxDistance)
        {
            _currentSpeed = 0;
            _currentForce = 0;
        }
       
    }

    private void Movement()
    {
        //A�ade fuerza necesaria para perseguir al objetivo marcado
        AddForce(Seek(player.position));

        //ejecuta el movimiento
        Move();
    }

    private void OnDrawGizmos()
    {
        //gizmo utilizado para visualizar la maxima distancia
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, _maxDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(player.transform.position, _visionDistance);
    }

}
