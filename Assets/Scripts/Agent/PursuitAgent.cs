using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitAgent : SteerinAgent
{
    //Fijar objetivo
    public Transform player;

    public Transform spawner;

    public Animator anim;

    private float _currentSpeed;
    private float _currentForce;
    
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _visionDistance;

    private void Update()
    {
        CheckDistanceAndMove();
    }

    private void CheckDistanceAndMove()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > _maxDistance && distanceToPlayer < _visionDistance)
        {
            //Añade fuerza necesaria para perseguir al objetivo marcado
            AddForce(Seek(player.position));
            //ejecuta el movimiento
            Move();
            anim.SetBool("run",true);
            anim.SetBool("attack", false);
        }
        else if (distanceToPlayer <= _maxDistance)
        {
            anim.SetBool("attack", true);
        }
         else if (distanceToPlayer >= _maxDistance && Vector3.Distance(spawner.position, transform.position) > 1f)
        {
            AddForce(Arrive(spawner.position));
            //ejecuta el movimiento
            Move();
            anim.SetBool("run", true);
            anim.SetBool("attack", false);
        }
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("attack", false);
        }

        

    }


    private void OnDrawGizmos()
    {
        //gizmo utilizado para visualizar la maxima distancia
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, _maxDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(player.transform.position, _visionDistance);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(spawner.transform.position, radius);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, _velocity);

        

    }

}
