using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAgent : SteerinAgent
{
    //Fijar objetivo
    public SteerinAgent target;

    //fijar un maximo y un minimo de distancia 
    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;

    private void Update()
    {
        //wn caso que la distancia maxima sea mayor a la menor acercarce caso contrario alejarse
        if(_maxDistance > _minDistance)
        {
            AddForce(Pursuit(target));
        }
        else
        {
            AddForce(Evade(target));
        }
        //ejecuta el movimiento
        Move();

    }

    private void OnDrawGizmos()
    {
        //gizmo utilizado para visualizar la maxima distancia
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(target.transform.position, _maxDistance);

        //gizmo utilizado para visualizar la minima distancia
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(target.transform.position, _minDistance);
    }
}
