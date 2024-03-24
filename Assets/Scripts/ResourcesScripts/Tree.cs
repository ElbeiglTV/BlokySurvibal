using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Resource, IreColectable
{
    public void Colect(int Damage)
    {
        life -= Damage;
        if(life<= 0)
        {
            ResourcesManager.instance.wood = value;
        }
    }
}
