using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyWeightPointer 
{
    public static AgentFlyWeight agentFlyWeight = new AgentFlyWeight()
    {
       maxForce = 0.060f,
       maxSpeed = 3,    
       radius = 7,
       maxDistance = 2,
       visionDistance = 5
    };
}
