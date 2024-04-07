using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerinAgent :MonoBehaviour
{
    private Vector3 _velocity;

    [SerializeField] protected float _maxSpeed;

    [Range(0,0.15f)][SerializeField] protected float _maxForce;


    protected void Move()
    {
        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }

    protected void AddForce(Vector3 force)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + force, _maxSpeed);
    }

    protected Vector3 Seek(Vector3 target)
    {
        return CalculateSteering((target - transform.position).normalized * _maxSpeed);
    }

    Vector3 CalculateSteering(Vector3 desired)
    {
        return Vector3.ClampMagnitude(desired - _velocity, _maxForce);
    }

    protected Vector3 Pursuit(SteerinAgent agent)
    {
   
        Vector3 futurePos = agent.transform.position + agent._velocity  ;
       
        if(Vector3.Distance(transform.position, futurePos) < (agent._velocity.magnitude))
        {
            Debug.DrawLine(transform.position, agent.transform.position, Color.green);
            return Seek(agent.transform.position);
        }

        Debug.DrawLine(transform.position, futurePos, Color.red);

        return Seek(futurePos);
    }

    protected Vector3 Evade(SteerinAgent agent)
    {
        return -Pursuit(agent);
    }

    
}


