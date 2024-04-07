using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitAgent : SteerinAgent
{
    public SteerinAgent target;

    private void Update()
    {
        AddForce(Pursuit(target));
        Move();
    }
}
