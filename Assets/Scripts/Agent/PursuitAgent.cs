using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitAgent : SteerinAgent
{
    //Fijar objetivo
    public Transform player;

    private void Update()
    {
       
        //Añade fuerza necesaria para perseguir al objetivo marcado
        AddForce(Seek(player.position));

        //ejecuta el movimiento
        Move();
    }
}
