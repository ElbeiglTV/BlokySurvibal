using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerinAgent :MonoBehaviour
{

    //inicializa la velocidad
    private Vector3 _velocity;

    //limita hasta que velocidad puede alcanzar
    [SerializeField] protected float _maxSpeed;

    //un rango de con que tanta fuerza el objeto se movera
    [Range(0,0.15f)][SerializeField] protected float _maxForce;

    //ejecuta y normaliza el tiempo de ejecucion del movimiento
    protected void Move()
    {
        transform.position += _velocity * Time.deltaTime;
        transform.forward = new Vector3 (_velocity.x, 0, _velocity.z);
    }

    //le da la fuerza necesaria con la cual se movera
    protected void AddForce(Vector3 force)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + force, _maxSpeed);
    }

    //busca al objetivo
    protected Vector3 Seek(Vector3 target)
    {
        return CalculateSteering((target - transform.position).normalized * _maxSpeed);
    }

    //fija al objetivo
    Vector3 CalculateSteering(Vector3 desired)
    {
        return Vector3.ClampMagnitude(desired - _velocity, _maxForce);
    }

    //persigue y calcula la proxima pocision del objetivo
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

    //huye del objetivo
    protected Vector3 Evade(SteerinAgent agent)
    {
        return -Pursuit(agent);
    }

    protected Vector3 Flee(Vector3 target)
    {
        return -Seek(target);
    }


}


