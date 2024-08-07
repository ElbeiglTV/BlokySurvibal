using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitAgent : SteerinAgent
{
    //Fijar objetivo
    public Transform player;
    public bool WaveEnemy;

    public Transform spawner;

    public Animator anim;

    public LayerMask obstacleMask;
    public float avoidDistance = 5f;
    public float avoidForce = 10f;


    /*private float _currentSpeed;
    private float _currentForce;*/
    
   

    private void Update()
    {
        if (WaveEnemy)
        {
            WaveMove();
        }
        else
        {
            CheckDistanceAndMove();
        }
    }

    private void CheckDistanceAndMove()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > FlyWeightPointer.agentFlyWeight.maxDistance && distanceToPlayer < FlyWeightPointer.agentFlyWeight.visionDistance)
        {
            //A�ade fuerza necesaria para perseguir al objetivo marcado
            AddForce(Seek(player.position));
            AvoidObstacles();
            //ejecuta el movimiento
            Move();
            anim.SetBool("run",true);
            anim.SetBool("attack", false);
        }
        else if (distanceToPlayer <= FlyWeightPointer.agentFlyWeight.maxDistance)
        {
            anim.SetBool("attack", true);
        }
         else if (distanceToPlayer >= FlyWeightPointer.agentFlyWeight.maxDistance && Vector3.Distance(spawner.position, transform.position) > 1f)
        {
            AddForce(Arrive(spawner.position));
            AvoidObstacles();
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
    private void WaveMove()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > FlyWeightPointer.agentFlyWeight.maxDistance && WaveEnemy)
        {
            //A�ade fuerza necesaria para perseguir al objetivo marcado
            AddForce(Seek(player.position));
            AvoidObstacles();
            //ejecuta el movimiento
            Move();
            anim.SetBool("run", true);
            anim.SetBool("attack", false);
        }
        else if (distanceToPlayer <= FlyWeightPointer.agentFlyWeight.maxDistance)
        {
            anim.SetBool("attack", true);
        }
        else
        {
            anim.SetBool("run", false);
            anim.SetBool("attack", false);
        }

    }

    private void AvoidObstacles()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, avoidDistance, obstacleMask))
        {
            Debug.Log("Avoiding obstacle!");
            Vector3 avoidDirection = Vector3.Reflect(transform.forward, hit.normal);
            AddForce(avoidDirection * avoidForce);
        }
    }


    private void OnDrawGizmos()
    {
        //gizmo utilizado para visualizar la maxima distancia
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.transform.position, FlyWeightPointer.agentFlyWeight.maxDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(player.transform.position, FlyWeightPointer.agentFlyWeight.visionDistance);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(spawner.transform.position, FlyWeightPointer.agentFlyWeight.radius);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, _velocity);

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * avoidDistance);

    }

}
