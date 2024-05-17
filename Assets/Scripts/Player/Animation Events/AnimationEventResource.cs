using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventResource : MonoBehaviour
{
   
    public FarmingTriguerControl control;
    public FarmingTriguerControl atackControll;

   public void Collect()
    {
        control.Colect();
    }

    public void AtackEvent()
    {
        atackControll.Shoot();

    } 
}
