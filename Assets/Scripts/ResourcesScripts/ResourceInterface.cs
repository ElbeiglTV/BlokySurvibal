using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IreColectable 
{

    /// <summary>
    /// Aplica daño a el recurso Que contenga la interface
    /// </summary>
    public void Colect(int Damage);
    public bool ActiveSelf();
    public void TogleSelect(bool mbool);
    public GameObject GetObject();
}
