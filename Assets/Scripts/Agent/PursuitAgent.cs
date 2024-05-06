using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitAgent : SteerinAgent
{
    //Fijar objetivo
    public SteerinAgent target;

    private void Update()
    {
        //Añade fuerza necesaria para perseguir al objetivo marcado
        AddForce(Pursuit(target));

        //ejecuta el movimiento
        Move();
    }
}
